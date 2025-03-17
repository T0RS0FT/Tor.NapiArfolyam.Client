using Tor.NapiArfolyam.Client.Enums;
using Tor.NapiArfolyam.Client.Helper;
using Tor.NapiArfolyam.Client.Internal;
using Tor.NapiArfolyam.Client.Internal.Models;

namespace Tor.NapiArfolyam.Client.Tests
{
    [TestClass]
    public class ResponseDeserializationTests
    {
        [TestMethod]
        public void GetExchangeRatesDeserializeTest()
        {
            var xml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Xml", "ExchangeRatesResponse.xml"));

            var model = XmlHelper.DeserializeXml<ExchangeRatesModel>(xml);

            var result = Mappers.ExchangeRates(model);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
            Assert.IsTrue(result.Count(x => x.CurrencyType == CurrencyType.Valuta) > 0);
            Assert.IsTrue(result.Count(x => x.CurrencyType == CurrencyType.Deviza) > 0);
            Assert.IsTrue(result.All(x => !string.IsNullOrWhiteSpace(x.CurrencyCode)));
            Assert.IsTrue(result.All(x => !string.IsNullOrWhiteSpace(x.BankCode)));
            Assert.IsTrue(result.All(x => x.SellingPrice > 0));
            Assert.IsTrue(result.All(x => x.BuyingPrice > 0));
            Assert.IsTrue(result.All(x => x.DateTime > DateTime.MinValue));
            Assert.IsTrue(result.All(x => x.DateTime < DateTime.MaxValue));
        }
    }
}
