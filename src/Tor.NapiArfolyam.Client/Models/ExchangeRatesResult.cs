using Tor.NapiArfolyam.Client.Enums;

namespace Tor.NapiArfolyam.Client.Models
{
    public class ExchangeRatesResult
    {
        public string BaseCurrencyCode { get; set; }

        public List<ExchangeRateResult> ExchangeRates { get; set; }
    }

    public class ExchangeRateResult
    {
        public string BankCode { get; set; }

        public CurrencyType CurrencyType { get; set; }

        public DateTime DateTime { get; set; }

        public string CurrencyCode { get; set; }

        public decimal BuyingPrice { get; set; }

        public decimal SellingPrice { get; set; }
    }
}
