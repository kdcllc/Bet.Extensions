# Bet.Extensions.Logging

[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg?style=flat-square)](https://raw.githubusercontent.com/kdcllc/Bet.Extensions/master/LICENSE)
[![Build status](https://ci.appveyor.com/api/projects/status/juk1eq7dy9l68mln?svg=true)](https://ci.appveyor.com/project/kdcllc/bet-extensions)
[![NuGet](https://img.shields.io/nuget/v/Bet.Extensions.Logging.svg)](https://www.nuget.org/packages?q=Bet.Extensions.Logging)
[![feedz.io](https://img.shields.io/badge/endpoint.svg?url=https://f.feedz.io/kdcllc/bet-extensions/shield/Bet.Extensions.Logging/latest)](https://f.feedz.io/kdcllc/bet-extensions/packages/Bet.Extensions.Logging/latest/download)

> The second letter in the Hebrew alphabet is the ב bet/beit. Its meaning is "house". In the ancient pictographic Hebrew it was a symbol resembling a tent on a landscape.

_Note: Pre-release packages are distributed via [feedz.io](https://f.feedz.io/kdcllc/bet-extensions/nuget/index.json)._

## Summary

This project extends logging functionality.

[![buymeacoffee](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/vyve0og)

## Give a Star! :star:

If you like or are using this project to learn or start your solution, please give it a star. Thanks!

## Install

```csharp
    dotnet add package Bet.Extensions.Logging
```

## Usage

Sometimes we need to have tracing information enable to see where the configuration details are loaded from.

```csharp

    new HostBuilder()
          .ConfigureAppConfiguration((context, configBuilder) =>
          {
               configBuilder.Build().DebugConfigurations();
          }
```

In order for this library to work with Microsoft ApplicationInsights please register the workers within DI:

```csharp
            .ConfigureServices(services =>
                {
                    services.AddApplicationInsightsTelemetryWorkerService();
                })
```
