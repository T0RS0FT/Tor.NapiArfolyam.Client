using Tor.NapiArfolyam.Client.Models;

namespace Tor.NapiArfolyam.Client
{
    public interface INapiArfolyamClient
    {
        Task<NapiArfolyamResponse<List<ExchangeRateModel>>> GetExchangesAsync();

        Task<NapiArfolyamResponse<List<ExchangeRateModel>>> GetExchangesAsync(ExchangeRateRequest request);
    }
}
