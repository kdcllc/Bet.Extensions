# Bet.Extensions.Options

[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg?style=flat-square)](https://raw.githubusercontent.com/kdcllc/Bet.Extensions/master/LICENSE)
[![Build status](https://ci.appveyor.com/api/projects/status/juk1eq7dy9l68mln?svg=true)](https://ci.appveyor.com/project/kdcllc/bet-extensions)
[![NuGet](https://img.shields.io/nuget/v/Bet.Extensions.Options.svg)](https://www.nuget.org/packages?q=Bet.Extensions.Options)
![Nuget](https://img.shields.io/nuget/dt/Bet.Extensions.Options)
[![feedz.io](https://img.shields.io/badge/endpoint.svg?url=https://f.feedz.io/kdcllc/bet-extensions/shield/Bet.Extensions.Options/latest)](https://f.feedz.io/kdcllc/bet-extensions/packages/Bet.Extensions.Options/latest/download)

> The second letter in the Hebrew alphabet is the ב bet/beit. Its meaning is "house". In the ancient pictographic Hebrew it was a symbol resembling a tent on a landscape.

_Note: Pre-release packages are distributed via [feedz.io](https://f.feedz.io/kdcllc/bet-extensions/nuget/index.json)._

## Summary

The collection of the functionality for Options Validations that can be utilized for AspNetCore or GenericHost.

[![buymeacoffee](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/vyve0og)

## Give a Star! :star:

If you like or are using this project to learn or start your solution, please give it a star. Thanks!

## Install

```bash
    dotnet add package Bet.Extensions.Options
```

## Usage

1. Validation of object on `Bind`; simply add this package to your application and use `Bind` validation extensions methods

```csharp
    var options = config.Bind<MyOptionsWithDatatAnnotations>(options);
```

2. Registering Options with `IOptionsMonitor`

```csharp
    builder.Services.AddChangeTokenOptions<AcmeAccountOptions>(
        section,
                options.NamedOption = builder.Name;
                options.Configured = true;
            });
```
