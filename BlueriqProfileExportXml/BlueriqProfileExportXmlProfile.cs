using AggregateReader.BlueriqObjects;
using System.Xml.Serialization;

namespace AggregateReader.BlueriqProfileExportXml
{
    [XmlRoot("profile")]
    public class BlueriqProfileExportXmlProfile
    {
		[XmlAttribute("appVersion")]
		public string? AppVersion { get; set; }

		[XmlAttribute("appName")]
		public string? AppName { get; set; }

		[XmlElement("entity")]
		public List<BlueriqProfileExportXmlEntity>? Entities { get; set; }
	}
}