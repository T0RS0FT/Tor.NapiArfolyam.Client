using Tor.NapiArfolyam.Client.Enums;
using Tor.NapiArfolyam.Client.Extensions;
using Tor.NapiArfolyam.Client.Helper;
using Tor.NapiArfolyam.Client.Internal;
using Tor.NapiArfolyam.Client.Internal.Models;
using Tor.NapiArfolyam.Client.Models;

namespace Tor.NapiArfolyam.Client
{
    public class NapiArfolyamClient(HttpClient httpClient) : INapiArfolyamClient
    {
        private readonly HttpClient httpClient = httpClient;

        public async Task<NapiArfolyamResponse<List<ExchangeRateModel>>> GetExchangesAsync()
            => await GetExchangesAsync(new ExchangeRateRequest());

        public async Task<NapiArfolyamResponse<List<ExchangeRateModel>>> GetExchangesAsync(ExchangeRateRequest request)
            => await GetExchangesAsync(request.BankCode, request.CurrencyCode, request.Date, request.EndDate, request.CurrencyType);

        private async Task<NapiArfolyamResponse<List<ExchangeRateModel>>> GetExchangesAsync(string bankCode, string currencyCode, DateOnly? date, DateOnly? endDate, CurrencyType? currencyType)
        {
            var queryParams = new List<string>();

            if (!string.IsNullOrWhiteSpace(bankCode))
            {
                queryParams.Add($"{Constants.QueryParameters.Bank}={bankCode}");
            }

            if (!string.IsNullOrWhiteSpace(currencyCode))
            {
                queryParams.Add($"{Constants.QueryParameters.Currency}={currencyCode}");
            }

            if (date != null)
            {
                queryParams.Add($"{Constants.QueryParameters.Date}={date.Value.ToNapiArfolyamFormat()}");
            }

            if (endDate != null)
            {
                queryParams.Add($"{Constants.QueryParameters.EndDate}={endDate.Value.ToNapiArfolyamFormat()}");
            }

            if (currencyType != null)
            {
                queryParams.Add($"{Constants.QueryParameters.CurrencyType}={currencyType.Value.ToCurrencyTypeCode()}");
            }

            var url = queryParams.Count == 0
                ? Constants.BaseUrl
                : $"{Constants.BaseUrl}?{string.Join("&", queryParams)}";

            var httpResponse = await httpClient.GetAsync(url);

            if (!httpResponse.IsSuccessStatusCode)
            {
                return new NapiArfolyamResponse<List<ExchangeRateModel>>()
                {
                    Success = false,
                    Result = null,
                    Error = Constants.Messages.HttpError
                };
            }

            var content = await httpResponse.Content.ReadAsStringAsync();

            if (content.StartsWith("<?xml"))
            {
                var result = XmlHelper.DeserializeXml<ExchangeRatesModel>(content);

                return new NapiArfolyamResponse<List<ExchangeRateModel>>()
                {
                    Success = true,
                    Result = Mappers.ExchangeRates(result),
                    Error = null,
                };
            }
            else
            {
                return new NapiArfolyamResponse<List<ExchangeRateModel>>()
                {
                    Success = false,
                    Result = null,
                    Error = content
                };
            }
        }
    }
}
