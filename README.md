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

#### Response object

Every method call will return with the following **NapiArfolyamResponse<TResult>** class:

```text
public class NapiArfolyamResponse<TResult>
{
    public bool Success { get; set; }

    public TResult Result { get; set; }

    public string Error { get; set; }
}
```

 - When the request succeed
   - Success: true
   - Error: null
   - Result: object
 - When the request failed
   - Success: false
   - Error: error message string
   - Result: null

#### INapiArfolyamClient.GetExchangesAsync method

Method parameters (you can call the method without any parameters, every parameter is optional):

| Property      | Description                     |
| ------------- | --------------------------------|
| BankCode      | Bank code                       |
| CurrencyCode  | The three letter Currency code  |
| Date          | Start date / date               |
| EndDate       | End date                        |
| CurrencyType  | Valuta / Deviza                 |

Response:

| Property                       | Description                     |
| ------------------------------ | --------------------------------|
| BaseCurrencyCode               | Three letter base currency code |
| ExchangeRates                  | Exchange rates                  |
| ExchangeRates -> BankCode      | Bank code                       |
| ExchangeRates -> CurrencyType  | Valuta / Deviza                 |
| ExchangeRates -> DateTime      | Date of the exchange rate       |
| ExchangeRates -> CurrencyCode  | Three letter currency code      |
| ExchangeRates -> BuyingPrice   | Buying price (can be null)      |
| ExchangeRates -> SellingPrice  | Selling price (can be null)     |
| ExchangeRates -> MidPrice      | Mid price (can be null)         |
