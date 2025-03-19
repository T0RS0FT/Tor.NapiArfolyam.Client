using Tor.NapiArfolyam.Client.Extensions;

namespace Tor.NapiArfolyam.Client.Tests
{
    [TestClass]
    public class DateOnlyExtensionsTests
    {
        [TestMethod]
        public void DateOnlyExtensionsToNapiArfolyamFormatTest()
        {
            var date = DateOnly.FromDateTime(DateTime.UtcNow);

            var expected = $"{date.Year:D4}{date.Month:D2}{date.Day:D2}";

            Assert.AreEqual(expected, date.ToNapiArfolyamFormat());
        }
    }
}
