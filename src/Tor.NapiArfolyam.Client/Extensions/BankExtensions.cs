using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using Tor.NapiArfolyam.Client.Attributes;
using Tor.NapiArfolyam.Client.Enums;
using Tor.NapiArfolyam.Client.Models;

namespace Tor.NapiArfolyam.Client.Extensions
{
    public static class BankExtensions
    {
        private static readonly ReadOnlyDictionary<BankType, string> BankTypeCodeDictionary;
        private static readonly ReadOnlyDictionary<string, BankType> BankCodeTypeDictionary;
        private static readonly IReadOnlyList<Bank> Banks;

        static BankExtensions()
        {
            var type = typeof(BankType);

            Banks = [.. Enum.GetValues<BankType>().Select(enumValue =>
            {
                var memberInfo = type.GetMember(enumValue.ToString())[0];

                return new Bank(
                    enumValue,
                    memberInfo.GetCustomAttribute<CodeAttribute>().Code,
                    memberInfo.GetCustomAttribute<DescriptionAttribute>().Description);
            })];

            BankTypeCodeDictionary = Banks
                .ToDictionary(x => x.BankType, x => x.Code)
                .AsReadOnly();

            BankCodeTypeDictionary = Banks
                .ToDictionary(x => x.Code, x => x.BankType)
                .AsReadOnly();
        }

        public static string ToBankCode(this BankType bankType)
            => BankTypeCodeDictionary[bankType];

        public static BankType? ToBankType(this string bankCode)
            => BankCodeTypeDictionary.TryGetValue(bankCode, out BankType value) ? value : null;
    }
}
