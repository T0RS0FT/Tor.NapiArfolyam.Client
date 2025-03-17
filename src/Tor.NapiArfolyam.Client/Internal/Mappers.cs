using System.Globalization;
using Tor.NapiArfolyam.Client.Enums;
using Tor.NapiArfolyam.Client.Internal.Models;
using Tor.NapiArfolyam.Client.Models;

namespace Tor.NapiArfolyam.Client.Internal
{
    internal class Mappers
    {
        internal static readonly Func<ExchangeRatesModel, List<ExchangeRateModel>> ExchangeRates = x => [
            ..x.Valuta?.Items?.Select(x => new ExchangeRateModel()
            {
                CurrencyType = CurrencyType.Valuta,
                BankCode = x.BankCode,
                DateTime = DateTime.Parse(x.DateTime, CultureInfo.InvariantCulture),
                CurrencyCode=x.CurrencyCode,
                BuyingPrice=x.BuyingPrice,
                SellingPrice=x.SellingPrice
            }),
            ..x.Deviza?.Items?.Select(x => new ExchangeRateModel()
            {
                CurrencyType = CurrencyType.Deviza,
                BankCode = x.BankCode,
                DateTime = DateTime.Parse(x.DateTime, CultureInfo.InvariantCulture),
                CurrencyCode=x.CurrencyCode,
                BuyingPrice=x.BuyingPrice,
                SellingPrice=x.SellingPrice
            })];
    }
}