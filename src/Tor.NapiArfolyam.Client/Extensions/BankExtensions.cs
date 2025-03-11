using System.ComponentModel;
using System.Reflection;
using Tor.NapiArfolyam.Client.Attributes;
using Tor.NapiArfolyam.Client.Enums;
using Tor.NapiArfolyam.Client.Models;

namespace Tor.NapiArfolyam.Client.Extensions
{
    internal static class BankExtensions
    {
        private static readonly IReadOnlyDictionary<BankTypes, string> BankTypeCodeDictionary;
        private static readonly IReadOnlyDictionary<string, BankTypes> BankCodeTypeDictionary;

        internal static readonly IReadOnlyList<Bank> Banks;

        static BankExtensions()
        {
            var type = typeof(BankTypes);

            Banks = [.. Enum.GetValues<BankTypes>().Select(enumValue =>
            {
                var memberInfo = type.GetMember(enumValue.ToString())[0];

                return new Bank(
                    enumValue,
                    memberInfo.GetCustomAttribute<BankCodeAttribute>().Code,
                    memberInfo.GetCustomAttribute<DescriptionAttribute>().Description);
            })];

            BankTypeCodeDictionary = Banks
                .ToDictionary(x => x.BankType, x => x.Code)
                .AsReadOnly();

            BankCodeTypeDictionary = Banks
                .ToDictionary(x => x.Code, x => x.BankType)
                .AsReadOnly();
        }

        internal static string ToBankCode(this BankTypes bankType)
            => BankTypeCodeDictionary[bankType];

        internal static BankTypes? ToBankType(this string bankCode)
            => BankCodeTypeDictionary.ContainsKey(bankCode) ? BankCodeTypeDictionary[bankCode] : null;
    }
}
