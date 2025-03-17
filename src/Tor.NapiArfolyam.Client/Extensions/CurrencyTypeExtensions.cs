using System.Collections.ObjectModel;
using System.Reflection;
using Tor.NapiArfolyam.Client.Attributes;
using Tor.NapiArfolyam.Client.Enums;

namespace Tor.NapiArfolyam.Client.Extensions
{
    public static class CurrencyTypeExtensions
    {
        private static readonly ReadOnlyDictionary<CurrencyType, string> CurrencyTypeCodeDictionary;
        private static readonly ReadOnlyDictionary<string, CurrencyType> CurrencyCodeTypeDictionary;

        static CurrencyTypeExtensions()
        {
            var type = typeof(CurrencyType);

            var enumValues = Enum.GetValues<CurrencyType>().Select(enumValue =>
            {
                var memberInfo = type.GetMember(enumValue.ToString())[0];

                return new
                {
                    EnumValue = enumValue,
                    Code = memberInfo.GetCustomAttribute<CodeAttribute>().Code
                };
            }).ToList();

            CurrencyTypeCodeDictionary = enumValues
                .ToDictionary(x => x.EnumValue, x => x.Code)
                .AsReadOnly();

            CurrencyCodeTypeDictionary = enumValues
                .ToDictionary(x => x.Code, x => x.EnumValue)
                .AsReadOnly();
        }

        public static string ToCurrencyTypeCode(this CurrencyType currencyType)
            => CurrencyTypeCodeDictionary[currencyType];

        public static CurrencyType? ToCurrencyType(this string currencyTypeCode)
            => CurrencyCodeTypeDictionary.TryGetValue(currencyTypeCode, out CurrencyType value) ? value : null;
    }
}
