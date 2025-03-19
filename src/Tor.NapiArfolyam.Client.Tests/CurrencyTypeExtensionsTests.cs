using Tor.NapiArfolyam.Client.Enums;
using Tor.NapiArfolyam.Client.Extensions;

namespace Tor.NapiArfolyam.Client.Tests
{
    [TestClass]
    public class CurrencyTypeExtensionsTests
    {
        [TestMethod]
        public void CurrencyTypeToCurrencyTypeCodeTest()
        {
            Enum.GetValues<CurrencyType>()
                .ToList()
                .ForEach(bankType => Assert.IsFalse(string.IsNullOrWhiteSpace(bankType.ToCurrencyTypeCode())));
        }
    }
}
