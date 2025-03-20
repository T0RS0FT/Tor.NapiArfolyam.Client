namespace Tor.NapiArfolyam.Client.Internal
{
    internal static class Constants
    {
        internal const string BaseCurrencyCode = "HUF";
        internal const string BaseUrl = "http://api.napiarfolyam.hu";

        internal static class QueryParameters
        {
            internal const string Bank = "bank";
            internal const string Currency = "valuta";
            internal const string Date = "datum";
            internal const string EndDate = "datumend";
            internal const string CurrencyType = "valutanem";
        }

        internal class Messages
        {
            internal const string HttpError = "An error occurred during the http request";
            internal const string SourceCurrencyCodeNotFound = "Source currency code not found";
            internal const string DestinationCurrencyCodeNotFound = "Destination currency code not found";
        }
    }
}
