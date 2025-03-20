using Tor.NapiArfolyam.Client.Models;

namespace Tor.NapiArfolyam.Client
{
    public interface INapiArfolyamClient
    {
        Task<bool> HealthCheckAsync();

        Task<NapiArfolyamResponse<ExchangeRatesResult>> GetExchangesAsync();

        Task<NapiArfolyamResponse<ExchangeRatesResult>> GetExchangesAsync(ExchangeRatesRequest request);
    }
}
