namespace Tor.NapiArfolyam.Client.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class CodeAttribute(string code) : Attribute
    {
        public readonly string Code = code;
    }
}
