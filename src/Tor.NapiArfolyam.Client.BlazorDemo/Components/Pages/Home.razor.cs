using Microsoft.AspNetCore.Components;

namespace Tor.NapiArfolyam.Client.BlazorDemo.Components.Pages
{
    public partial class Home
    {
        [Inject]
        private INapiArfolyamClient NapiArfolyamClient { get; set; }

        private string logs = string.Empty;

        private async Task HealthCheck()
        {
            var result = await NapiArfolyamClient.HealthCheckAsync();

            logs += result
                ? $"Service is available{Environment.NewLine}"
                : $"Service is not available{Environment.NewLine}";
        }
    }
}
