# Tor.NapiArfolyam.Client

[![](https://img.shields.io/nuget/dt/Tor.NapiArfolyam.Client)](#) [![](https://img.shields.io/nuget/v/Tor.NapiArfolyam.Client)](https://www.nuget.org/packages/Tor.NapiArfolyam.Client)

A C# client library for [NapiArfolyamm.hu]([https://www.napiarfolyam.hu/](https://www.napiarfolyam.hu/)) API with dependency injection support.

## Installation

```text
Install-Package Tor.Mnb.Client
```

## Usage

> **_NOTE:_**  The base currency is always HUF (Hungarian Forint), but you don't have to hard code this, you can get this information from the **INapiArfolyamClient.BaseCurrencyCode** property.

### Registering to .NET Core service collection

You have to register the **NapiArgolyamClient** with the dependencies in the Program.cs file.

```text
services.AddNapiArfolyam();
```

### INapiArfolyamClient usage

You can get the **INapiArfolyamClient** via dependency injection:

```text
public class MyService
{
    public MyService(INapiArfolyamClient client)
    {
    }   
}
```

#### INapiArfolyamClient.GetExchangesAsync method
