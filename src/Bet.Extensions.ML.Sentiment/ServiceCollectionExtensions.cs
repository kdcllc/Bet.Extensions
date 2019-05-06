﻿using Bet.Extensions.ML.ModelBuilder;
using Bet.Extensions.ML.Sentiment;
using Bet.Extensions.ML.Sentiment.Models;

using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.ML;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSentimentModelGenerator(this IServiceCollection services)
        {
            services.TryAddSingleton(new MLContext());
            services.TryAddScoped<IModelCreationBuilder<SentimentIssue, SentimentPrediction, BinaryClassificationMetricsResult>,
                SentimentModelBuilder<SentimentIssue, SentimentPrediction, BinaryClassificationMetricsResult>>();
            return services;
        }
    }
}
