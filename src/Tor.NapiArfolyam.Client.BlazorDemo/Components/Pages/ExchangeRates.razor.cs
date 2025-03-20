using Microsoft.AspNetCore.Components;
using Tor.NapiArfolyam.Client.Models;

namespace Tor.NapiArfolyam.Client.BlazorDemo.Components.Pages
{
    public partial class ExchangeRates
    {
        [Inject]
        private INapiArfolyamClient NapiArfolyamClient { get; set; }

        private readonly ExchangeRatesRequest request = new();
        private string error = string.Empty;
        private bool hasError = false;
        private bool hasData = false;
        private ExchangeRatesResult exchangeRates;

        private async Task LoadData()
        {
            var result = await NapiArfolyamClient.GetExchangesAsync(request);

            hasData = result.Success;
            hasError = !result.Success;
            error = result.Error;
            exchangeRates = result.Result;
        }
    }
}
