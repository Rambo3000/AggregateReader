using System.Xml;
using System.Xml.Linq;

namespace AggregateReader.Helpers
{
    public static class XmlHelper
    {
        public static string PrettyPrint(string xml)
        {
            try
            {
                XDocument doc = XDocument.Parse(xml);
                return doc.ToString();
            }
            catch (Exception)
            {
                // Handle and throw if fatal exception here; don't just ignore them
                return xml;
            }
        }
        public static bool IsValidXml(string xml)
        {
            try
            {
                XmlDocument xmlDoc = new();
                xmlDoc.LoadXml(xml);
                return true; // XML is valid
            }
            catch (XmlException)
            {
                return false; // XML is not valid
            }
        }
    }
}
