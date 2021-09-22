# Bet.Extensions.HealthChecks.AzureStorage

[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg?style=flat-square)](https://raw.githubusercontent.com/kdcllc/Bet.Extensions/master/LICENSE)
[![Build status](https://ci.appveyor.com/api/projects/status/juk1eq7dy9l68mln?svg=true)](https://ci.appveyor.com/project/kdcllc/bet-extensions)
[![NuGet](https://img.shields.io/nuget/v/Bet.Extensions.HealthChecks.AzureStorage.svg)](https://www.nuget.org/packages?q=Bet.Extensions.HealthChecks.AzureStorage)
![Nuget](https://img.shields.io/nuget/dt/Bet.Extensions.HealthChecks.AzureStorage)
[![feedz.io](https://img.shields.io/badge/endpoint.svg?url=https://f.feedz.io/kdcllc/bet-extensions/shield/Bet.Extensions.HealthChecks.AzureStorage/latest)](https://f.feedz.io/kdcllc/bet-extensions/packages/Bet.Extensions.HealthChecks.AzureStorage/latest/download)

> The second letter in the Hebrew alphabet is the ב bet/beit. Its meaning is "house". In the ancient pictographic Hebrew it was a symbol resembling a tent on a landscape.

_Note: Pre-release packages are distributed via [feedz.io](https://f.feedz.io/kdcllc/bet-extensions/nuget/index.json)._

## Summary

The healthcheck for Azure Storage with Microsoft Managed Identity (MSI).

[![buymeacoffee](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/vyve0og)

## Give a Star! :star:

If you like or are using this project to learn or start your solution, please give it a star. Thanks!

## Install

```bash
    dotnet add package Bet.Extensions.HealthChecks.AzureStorage
```

## Usage

1. Add `HealthCheck` configuration in `ConfigureServices`.

```csharp
  services.AddHealthChecks()
                .AddMemoryHealthCheck()
                .AddMachineLearningModelCheck<SpamInput, SpamPrediction>("spam_check")
                .AddMachineLearningModelCheck<SentimentIssue, SentimentPrediction>("sentiment_check")
                .AddSigtermCheck("sigterm_check")
                .AddLoggerPublisher(new List<string> { "sigterm_check" });
```
