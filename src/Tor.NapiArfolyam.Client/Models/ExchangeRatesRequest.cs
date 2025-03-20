using Tor.NapiArfolyam.Client.Enums;

namespace Tor.NapiArfolyam.Client.Models
{
    public class ExchangeRatesRequest
    {
        public string BankCode { get; set; }

        public string CurrencyCode { get; set; }

        public DateOnly? Date { get; set; }

        public DateOnly? EndDate { get; set; }

        public CurrencyType? CurrencyType { get; set; }
    }
}
