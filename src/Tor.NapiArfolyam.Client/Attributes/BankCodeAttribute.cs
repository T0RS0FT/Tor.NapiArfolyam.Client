namespace Tor.NapiArfolyam.Client.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class BankCodeAttribute(string code) : Attribute
    {
        public readonly string Code = code;
    }
}
