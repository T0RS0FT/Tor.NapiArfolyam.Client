namespace Tor.NapiArfolyam.Client
{
    public class NapiArfolyamClient(HttpClient httpClient) : INapiArfolyamClient
    {
        private readonly HttpClient httpClient = httpClient;
    }
}
