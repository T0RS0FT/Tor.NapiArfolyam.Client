using System.ComponentModel;
using Tor.NapiArfolyam.Client.Attributes;

namespace Tor.NapiArfolyam.Client.Enums
{
    public enum BankType
    {
        [Code("bb")]
        [Description("Budapest Bank")]
        BudapestBank,

        [Code("allianz")]
        [Description("Allianz")]
        Allianz,

        [Code("cib")]
        [Description("CIB Bank")]
        Cib,

        [Code("citibank")]
        [Description("Citibank")]
        Citibank,

        [Code("commerz")]
        [Description("Commerzbank")]
        Commerzbank,

        [Code("erste")]
        [Description("Erste Bank")]
        Erste,

        [Code("kdb")]
        [Description("KDB Bank")]
        Kdb,

        [Code("kh")]
        [Description("K&H Bank")]
        Kh,

        [Code("mkb")]
        [Description("MKB Bank")]
        Mkb,

        [Code("oberbank")]
        [Description("Oberbank")]
        Oberbank,

        [Code("otp")]
        [Description("OTP Bank")]
        Otp,

        [Code("raiffeisen")]
        [Description("Raiffeisen Bank")]
        Raiffeisen,

        [Code("unicredit")]
        [Description("UniCredit Bank")]
        UniCredit,

        [Code("volksbank")]
        [Description("Volksbank")]
        Volksbank,

        [Code("mnb")]
        [Description("Magyar Nemzeti Bank")]
        Mnb,

        [Code("sopron")]
        [Description("Sopron Bank")]
        Sopron,

        [Code("mfb")]
        [Description("Magyar Fejlesztési Bank")]
        Mfb,

        [Code("fhb")]
        [Description("FHB Bank")]
        Fhb
    }
}