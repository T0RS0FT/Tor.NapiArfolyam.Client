namespace Tor.NapiArfolyam.Client.Models
{
    public class NapiArfolyamResponse<TResult>
    {
        public bool Success { get; set; }

        public TResult Result { get; set; }

        public string Error { get; set; }
    }
}
