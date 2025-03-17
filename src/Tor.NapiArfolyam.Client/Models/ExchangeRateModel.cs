using Tor.NapiArfolyam.Client.Enums;

namespace Tor.NapiArfolyam.Client.Models
{
    public class ExchangeRateModel
    {
        public string BankCode { get; set; }

        public CurrencyType CurrencyType { get; set; }

        public DateTime DateTime { get; set; }

        public string CurrencyCode { get; set; }

        public decimal BuyingPrice { get; set; }

        public decimal SellingPrice { get; set; }
    }
}
