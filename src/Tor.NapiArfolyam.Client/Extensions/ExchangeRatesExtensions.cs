using Tor.NapiArfolyam.Client.Enums;
using Tor.NapiArfolyam.Client.Internal;
using Tor.NapiArfolyam.Client.Models;

namespace Tor.NapiArfolyam.Client.Extensions
{
    public static class ExchangeRatesExtensions
    {
        public static decimal Convert(
            this ExchangeRatesResult rates,
            string sourceCurrencyCode,
            string destinationCurrencyCode,
            decimal quantity,
            ExchangeRateFindMode findMode = ExchangeRateFindMode.Newest,
            ExchangeRateCalculateMode calculateMode = ExchangeRateCalculateMode.MidPrice)
        {
            ArgumentNullException.ThrowIfNull(rates);
            ArgumentException.ThrowIfNullOrWhiteSpace(sourceCurrencyCode);
            ArgumentException.ThrowIfNullOrWhiteSpace(destinationCurrencyCode);

            if (sourceCurrencyCode.IgnoreCaseEquals(destinationCurrencyCode))
            {
                return quantity;
            }

            if (sourceCurrencyCode.IgnoreCaseEquals(rates.BaseCurrencyCode))
            {
                var exchangeRate = FindExchangeRate(rates, destinationCurrencyCode, findMode);

                return exchangeRate == null
                    ? throw new Exception(Constants.Messages.DestinationCurrencyCodeNotFound)
                    : 1 / exchangeRate.GetExchangeRate(calculateMode) * quantity;
            }

            if (destinationCurrencyCode.IgnoreCaseEquals(rates.BaseCurrencyCode))
            {
                var exchangeRate = FindExchangeRate(rates, sourceCurrencyCode, findMode);

                return exchangeRate == null
                    ? throw new Exception(Constants.Messages.SourceCurrencyCodeNotFound)
                    : exchangeRate.GetExchangeRate(calculateMode) * quantity;
            }

            var sourceRate = FindExchangeRate(rates, sourceCurrencyCode, findMode)
                ?? throw new Exception(Constants.Messages.SourceCurrencyCodeNotFound);
            var destinationRate = FindExchangeRate(rates, destinationCurrencyCode, findMode)
                ?? throw new Exception(Constants.Messages.DestinationCurrencyCodeNotFound);

            return 1 / (destinationRate.GetExchangeRate(calculateMode) / sourceRate.GetExchangeRate(calculateMode)) * quantity;
        }

        public static List<string> GetCurrencyCodes(this ExchangeRatesResult rates)
        {
            return rates == null
                ? []
                : [.. new List<string>([.. rates.ExchangeRates.Select(x => x.CurrencyCode), rates.BaseCurrencyCode]).Distinct().OrderBy(x => x)];
        }

        public static ExchangeRateResult FindExchangeRate(this ExchangeRatesResult rates, string currencyCode, ExchangeRateFindMode findMode)
        {
            return currencyCode == null ||
                rates == null ||
                rates.ExchangeRates == null ||
                rates.ExchangeRates.Count == 0 ||
                currencyCode.IgnoreCaseEquals(rates.BaseCurrencyCode)
                    ? null
                    : findMode switch
                    {
                        ExchangeRateFindMode.First => rates.ExchangeRates
                            .FirstOrDefault(x => currencyCode.IgnoreCaseEquals(x.CurrencyCode)),
                        ExchangeRateFindMode.Last => rates.ExchangeRates
                            .LastOrDefault(x => currencyCode.IgnoreCaseEquals(x.CurrencyCode)),
                        ExchangeRateFindMode.Oldest => rates.ExchangeRates
                            .OrderBy(x => x.DateTime)
                            .FirstOrDefault(x => currencyCode.IgnoreCaseEquals(x.CurrencyCode)),
                        ExchangeRateFindMode.Newest => rates.ExchangeRates
                            .OrderByDescending(x => x.DateTime)
                            .FirstOrDefault(x => currencyCode.IgnoreCaseEquals(x.CurrencyCode)),
                        ExchangeRateFindMode.CheapestBuyingPrice => rates.ExchangeRates
                            .OrderBy(x => x.BuyingPrice ?? decimal.MaxValue)
                            .ThenBy(x => x.MidPrice)
                            .FirstOrDefault(x => currencyCode.IgnoreCaseEquals(x.CurrencyCode)),
                        ExchangeRateFindMode.CheapestSellingPrice => rates.ExchangeRates
                            .OrderBy(x => x.SellingPrice ?? decimal.MaxValue)
                            .ThenBy(x => x.MidPrice)
                            .FirstOrDefault(x => currencyCode.IgnoreCaseEquals(x.CurrencyCode)),
                        ExchangeRateFindMode.CheapestAveragePrice => rates.ExchangeRates
                            .OrderBy(x => x.MidPrice ?? (x.BuyingPrice ?? 0 + x.SellingPrice ?? 0) / 2)
                            .FirstOrDefault(x => currencyCode.IgnoreCaseEquals(x.CurrencyCode)),
                        ExchangeRateFindMode.MostExpensiveBuyingPrice => rates.ExchangeRates
                            .OrderByDescending(x => x.BuyingPrice ?? decimal.MaxValue)
                            .ThenByDescending(x => x.MidPrice)
                            .FirstOrDefault(x => currencyCode.IgnoreCaseEquals(x.CurrencyCode)),
                        ExchangeRateFindMode.MostExpensiveSellingPrice => rates.ExchangeRates
                            .OrderByDescending(x => x.SellingPrice ?? decimal.MaxValue)
                            .ThenByDescending(x => x.MidPrice)
                            .FirstOrDefault(x => currencyCode.IgnoreCaseEquals(x.CurrencyCode)),
                        ExchangeRateFindMode.MostExpensiveAveragePrice => rates.ExchangeRates
                            .OrderByDescending(x => x.MidPrice ?? (x.BuyingPrice ?? 0 + x.SellingPrice ?? 0) / 2)
                            .FirstOrDefault(x => currencyCode.IgnoreCaseEquals(x.CurrencyCode)),
                        _ => throw new NotSupportedException(),
                    };
        }

        private static decimal GetExchangeRate(this ExchangeRateResult rate, ExchangeRateCalculateMode calculateMode)
        {
            return calculateMode switch
            {
                ExchangeRateCalculateMode.BuyingPrice => rate.BuyingPrice ?? rate.MidPrice ?? 0,
                ExchangeRateCalculateMode.SellingPrice => rate.SellingPrice ?? rate.MidPrice ?? 0,
                ExchangeRateCalculateMode.MidPrice => rate.MidPrice ?? ((rate.BuyingPrice ?? 0) + (rate.SellingPrice ?? 0)) / 2,
                _ => throw new NotSupportedException(),
            };
        }
    }
}
