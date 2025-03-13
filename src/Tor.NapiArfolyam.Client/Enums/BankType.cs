using System.ComponentModel;
using Tor.NapiArfolyam.Client.Attributes;

namespace Tor.NapiArfolyam.Client.Enums
{
    public enum BankType
    {
        [BankCode("bb")]
        [Description("Budapest Bank")]
        BudapestBank,

        [BankCode("allianz")]
        [Description("Allianz")]
        Allianz,

        [BankCode("cib")]
        [Description("CIB Bank")]
        Cib,

        [BankCode("citibank")]
        [Description("Citibank")]
        Citibank,

        [BankCode("commerz")]
        [Description("Commerzbank")]
        Commerzbank,

        [BankCode("erste")]
        [Description("Erste Bank")]
        Erste,

        [BankCode("kdb")]
        [Description("KDB Bank")]
        Kdb,

        [BankCode("kh")]
        [Description("K&H Bank")]
        Kh,

        [BankCode("mkb")]
        [Description("MKB Bank")]
        Mkb,

        [BankCode("oberbank")]
        [Description("Oberbank")]
        Oberbank,

        [BankCode("otp")]
        [Description("OTP Bank")]
        Otp,

        [BankCode("raiffeisen")]
        [Description("Raiffeisen Bank")]
        Raiffeisen,

        [BankCode("unicredit")]
        [Description("UniCredit Bank")]
        UniCredit,

        [BankCode("volksbank")]
        [Description("Volksbank")]
        Volksbank,

        [BankCode("mnb")]
        [Description("Magyar Nemzeti Bank")]
        Mnb,

        [BankCode("sopron")]
        [Description("Sopron Bank")]
        Sopron,

        [BankCode("mfb")]
        [Description("Magyar Fejlesztési Bank")]
        Mfb,

        [BankCode("fhb")]
        [Description("FHB Bank")]
        Fhb
    }
}