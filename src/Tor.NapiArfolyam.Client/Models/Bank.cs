using Tor.NapiArfolyam.Client.Enums;

namespace Tor.NapiArfolyam.Client.Models
{
    public class Bank(BankType bankType, string code, string name)
    {
        public readonly BankType BankType = bankType;
        public readonly string Code = code;
        public readonly string Name = name;
    }
}