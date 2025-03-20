using Tor.NapiArfolyam.Client.Extensions;
using Tor.NapiArfolyam.Client.Models;

namespace Tor.NapiArfolyam.Client.Tests
{
    [TestClass]
    public class ExchangeRatesExtensionsTests
    {
        [DataTestMethod]
        [DataRow("EUR", "EUR", 1, true, 1)]
        [DataRow("eur", "EUR", 1, true, 1)]
        [DataRow("EUR", "eur", 1, true, 1)]
        [DataRow("eur", "eur", 1, true, 1)]
        [DataRow("EUR", "EUR", 10, true, 10)]
        [DataRow("EUR", "USD", 1, true, 1.04)]
        [DataRow("EUR", "USD", 2, true, 2.08)]
        [DataRow("USD", "EUR", 1, true, 0.96)]
        [DataRow("USD", "EUR", 5, true, 4.8)]
        [DataRow("USD", "GBP", 1, true, 0.81)]
        [DataRow("USD", "GBP", 10, true, 8.17)]
        [DataRow("USD", "USB", 1, false, 0)]
        [DataRow("USB", "USC", 1, false, 0)]
        [DataRow("USB", "USD", 1, false, 0)]
        [DataRow("", "USD", 1, false, 0)]
        [DataRow("USD", "", 1, false, 0)]
        [DataRow("", "", 1, false, 0)]
        [DataRow(null, "USD", 1, false, 0)]
        [DataRow("USD", null, 1, false, 0)]
        [DataRow(null, null, 1, false, 0)]
        [DataRow("  ", "USD", 1, false, 0)]
        [DataRow("USD", "   ", 1, false, 0)]
        [DataRow("  ", "    ", 1, false, 0)]
        public void ExchangeRatesExtensionsGetCurrencyCodesTest(
            string sourceCurrencyCode,
            string destinationCurrencyCode,
            double amount,
            bool success,
            double expectedResult)
        {
            var rates = new ExchangeRatesResult()
            {
                BaseCurrencyCode = "EUR",
                ExchangeRates =
                [
                    new ExchangeRateResult(){ CurrencyCode="USD", BuyingPrice=0.9615m, SellingPrice=0.9615m, MidPrice=0.9615m, DateTime=DateTime.UtcNow },
                    new ExchangeRateResult(){ CurrencyCode="GBP", BuyingPrice=1.1764m, SellingPrice=1.1764m ,MidPrice=1.1764m, DateTime=DateTime.UtcNow }
                ]
            };

            try
            {
                var result = rates.Convert(sourceCurrencyCode, destinationCurrencyCode, (decimal)amount);

                Assert.IsTrue(Math.Abs((decimal)expectedResult - result) < 0.01m);
            }
            catch (Exception ex)
            {
                if (success)
                {
                    Assert.Fail(ex.Message);
                }
            }
        }
    }
}
