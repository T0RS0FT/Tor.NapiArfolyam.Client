using System.Xml.Serialization;

namespace Tor.NapiArfolyam.Client.Internal.Models
{
    /// <summary>
    /// Internal usage only, but XmlSerializer does not support internal classes
    /// </summary>
    [XmlRoot(ElementName = "arfolyamok")]
    public class ExchangeRatesModel
    {
        [XmlElement(ElementName = "valuta")]
        public ValutaModel Valuta { get; set; }

        [XmlElement(ElementName = "deviza")]
        public DevizaModel Deviza { get; set; }
    }

    /// <summary>
    /// Internal usage only, but XmlSerializer does not support internal classes
    /// </summary>
    [XmlRoot(ElementName = "valuta")]
    public class ValutaModel
    {
        [XmlElement(ElementName = "item")]
        public List<ItemModel> Items { get; set; }
    }

    /// <summary>
    /// Internal usage only, but XmlSerializer does not support internal classes
    /// </summary>
    [XmlRoot(ElementName = "deviza")]
    public class DevizaModel
    {
        [XmlElement(ElementName = "item")]
        public List<ItemModel> Items { get; set; }
    }

    /// <summary>
    /// Internal usage only, but XmlSerializer does not support internal classes
    /// </summary>
    [XmlRoot(ElementName = "item")]
    public class ItemModel
    {
        [XmlElement(ElementName = "bank")]
        public string BankCode { get; set; }

        [XmlElement(ElementName = "datum")]
        public string DateTime { get; set; }

        [XmlElement(ElementName = "penznem")]
        public string CurrencyCode { get; set; }

        [XmlElement(ElementName = "vetel")]
        public decimal BuyingPrice { get; set; }

        [XmlElement(ElementName = "eladas")]
        public decimal SellingPrice { get; set; }
    }
}
