using Tor.NapiArfolyam.Client.Enums;

namespace Tor.NapiArfolyam.Client.Models
{
    public class Bank(BankTypes bankType, string code, string name)
    {
        public readonly BankTypes BankType = bankType;
        public readonly string Code = code;
        public readonly string Name = name;
    }
}