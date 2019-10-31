﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bet.Extensions.HealthChecks.AzureStorage
{
    public class StorageAccountOptionsSetup : IPostConfigureOptions<StorageAccountOptions>
    {
        private readonly ILogger<StorageAccountOptionsSetup> _logger;

        public StorageAccountOptionsSetup(ILogger<StorageAccountOptionsSetup> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void PostConfigure(string name, StorageAccountOptions options)
        {
            if (options.CloudStorageAccount == null)
            {
                options.CloudStorageAccount = new Lazy<Task<CloudStorageAccount>>(async () => await GetStorageAccountAsync(options, CancellationToken.None));
            }
        }

        private async Task<NewTokenAndFrequency> TokenRenewerAsync(object state, CancellationToken cancellationToken)
        {
            var sw = ValueStopwatch.StartNew();

            cancellationToken.ThrowIfCancellationRequested();

            var (authResult, next) = await GetToken(state);

            _logger.LogInformation("Azure Storage Authentication duration: {0}", sw.GetElapsedTime().TotalSeconds);

            if (next.Ticks < 0)
            {
                next = default;

                _logger.LogInformation("Azure Storage Authentication Renewing Token...");

                var swr = ValueStopwatch.StartNew();

                (authResult, next) = await GetToken(state);

                _logger.LogInformation("Azure Storage Authentication Renewing Token duration: {0}", swr.GetElapsedTime().TotalSeconds);
            }

            // Return the new token and the next refresh time.
            return new NewTokenAndFrequency(authResult.AccessToken, next);
        }

        // https://github.com/MicrosoftDocs/azure-docs/blob/941ccc038829a0be5fa8515ffba9956cfc02a5e6/articles/storage/common/storage-auth-aad-msi.md
        private async Task<(AppAuthenticationResult result, TimeSpan ticks)> GetToken(object state)
        {
            // Specify the resource ID for requesting Azure AD tokens for Azure Storage.
            const string StorageResource = "https://storage.azure.com/";

            // Use the same token provider to request a new token.
            var authResult = await ((AzureServiceTokenProvider)state).GetAuthenticationResultAsync(StorageResource);

            // Renew the token 5 minutes before it expires.
            var next = authResult.ExpiresOn - DateTimeOffset.UtcNow - TimeSpan.FromMinutes(5);

            // debug purposes
            // var next = (authResult.ExpiresOn - authResult.ExpiresOn) + TimeSpan.FromSeconds(15);
            return (authResult, next);
        }

        private async Task<CloudStorageAccount> GetStorageAccountAsync(StorageAccountOptions options, CancellationToken cancellationToken = default)
        {
            CloudStorageAccount account;

            if (!string.IsNullOrEmpty(options.ConnectionString)
                && CloudStorageAccount.TryParse(options.ConnectionString, out var cloudStorageAccount))
            {
                account = cloudStorageAccount;

                _logger.LogInformation("Azure Storage Authentication with ConnectionString.");
            }
            else if (!string.IsNullOrEmpty(options.Name)
                && string.IsNullOrEmpty(options.Token))
            {
                // Get the initial access token and the interval at which to refresh it.
                var azureServiceTokenProvider = new AzureServiceTokenProvider();
                var tokenAndFrequency = await TokenRenewerAsync(
                    azureServiceTokenProvider,
                    cancellationToken);

                // Create storage credentials using the initial token, and connect the callback function
                // to renew the token just before it expires
#pragma warning disable CA2000 // Dispose objects before losing scope
                var tokenCredential = new TokenCredential(
                    tokenAndFrequency.Token,
                    TokenRenewerAsync,
                    azureServiceTokenProvider,
#pragma warning disable CS8629 // Nullable value type may be null.
                    tokenAndFrequency.Frequency.Value);
#pragma warning restore CS8629 // Nullable value type may be null.
#pragma warning restore CA2000 // Dispose objects before losing scope

                var storageCredentials = new StorageCredentials(tokenCredential);

                account = new CloudStorageAccount(storageCredentials, options.Name, string.Empty, true);

                _logger.LogInformation("Azure Storage Authentication with MSI Token.");
            }
            else if (!string.IsNullOrEmpty(options.Name)
                && !string.IsNullOrEmpty(options.Token))
            {
                account = new CloudStorageAccount(new StorageCredentials(options.Token), options.Name, true);
                _logger.LogInformation("Azure Storage Authentication with SAS Token.");
            }
            else
            {
                throw new ArgumentException($"One of the following must be set: '{options.ConnectionString}' or '{options.Name}'!");
            }

            return account;
        }
    }
}
