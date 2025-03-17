using System.Xml.Serialization;

namespace Tor.NapiArfolyam.Client.Helper
{
    public static class XmlHelper
    {
        public static T DeserializeXml<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var reader = new StringReader(xml))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
