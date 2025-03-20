using System.Globalization;
using Tor.NapiArfolyam.Client.Enums;
using Tor.NapiArfolyam.Client.Internal.Models;
using Tor.NapiArfolyam.Client.Models;

namespace Tor.NapiArfolyam.Client.Internal
{
    internal class Mappers
    {
        internal static readonly Func<ExchangeRatesModel, ExchangeRatesResult> ExchangeRates = x => new ExchangeRatesResult()
        {
            BaseCurrencyCode = Constants.BaseCurrencyCode,
            ExchangeRates = [
                ..x.Valuta?.Items?.Select(x => new ExchangeRateResult()
                {
                    CurrencyType = CurrencyType.Valuta,
                    BankCode = x.BankCode,
                    DateTime = DateTime.Parse(x.DateTime, CultureInfo.InvariantCulture),
                    CurrencyCode=x.CurrencyCode,
                    BuyingPrice=x.BuyingPrice,
                    SellingPrice=x.SellingPrice
                }),
                ..x.Deviza?.Items?.Select(x => new ExchangeRateResult()
                {
                    CurrencyType = CurrencyType.Deviza,
                    BankCode = x.BankCode,
                    DateTime = DateTime.Parse(x.DateTime, CultureInfo.InvariantCulture),
                    CurrencyCode=x.CurrencyCode,
                    BuyingPrice=x.BuyingPrice,
                    SellingPrice=x.SellingPrice
                })]
        };
    }
}