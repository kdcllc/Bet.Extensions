# Bet.Extensions.Testing

[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg?style=flat-square)](https://raw.githubusercontent.com/kdcllc/Bet.Extensions/master/LICENSE)
[![Build status](https://ci.appveyor.com/api/projects/status/juk1eq7dy9l68mln?svg=true)](https://ci.appveyor.com/project/kdcllc/bet-extensions)
[![NuGet](https://img.shields.io/nuget/v/Bet.Extensions.Testing.svg)](https://www.nuget.org/packages?q=Bet.Extensions.Testing)
![Nuget](https://img.shields.io/nuget/dt/Bet.Extensions.Testing)
[![feedz.io](https://img.shields.io/badge/endpoint.svg?url=https://f.feedz.io/kdcllc/bet-extensions/shield/Bet.Extensions.Testing/latest)](https://f.feedz.io/kdcllc/bet-extensions/packages/Bet.Extensions.Testing/latest/download)

> The second letter in the Hebrew alphabet is the ב bet/beit. Its meaning is "house". In the ancient pictographic Hebrew it was a symbol resembling a tent on a landscape.

_Note: Pre-release packages are distributed via [feedz.io](https://f.feedz.io/kdcllc/bet-extensions/nuget/index.json)._

## Summary

The library for the XUnit testing of DotNetCore Applications.

[![buymeacoffee](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/vyve0og)

## Give a Star! :star:

If you like or are using this project to learn or start your solution, please give it a star. Thanks!

## Install

```bash
    dotnet add package Bet.Extensions.Testing
```

## Usage

```csharp
    var logFactory = TestLoggerBuilder.Create(builder =>
    {
        builder.AddConsole();
        builder.AddDebug();
        builder.AddXunit(outputHelper, LogLevel.Debug);
    });
```
