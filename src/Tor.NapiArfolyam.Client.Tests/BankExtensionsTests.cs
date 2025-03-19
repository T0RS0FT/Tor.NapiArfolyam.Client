using Tor.NapiArfolyam.Client.Enums;
using Tor.NapiArfolyam.Client.Extensions;

namespace Tor.NapiArfolyam.Client.Tests
{
    [TestClass]
    public class BankExtensionsTests
    {
        [TestMethod]
        public void BankTypeToBankCodeTest()
        {
            Enum.GetValues<BankType>()
                .ToList()
                .ForEach(bankType => Assert.IsFalse(string.IsNullOrWhiteSpace(bankType.ToBankCode())));
        }
    }
}
