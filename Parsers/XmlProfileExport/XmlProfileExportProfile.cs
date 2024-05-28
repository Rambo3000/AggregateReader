using System.Xml.Serialization;

namespace AggregateReader.Parsers.XmlProfileExport
{
    [XmlRoot("profile")]
    public class XmlProfileExportProfile
    {
		[XmlAttribute("appVersion")]
		public string? AppVersion { get; set; }

		[XmlAttribute("appName")]
		public string? AppName { get; set; }

		[XmlElement("entity")]
		public List<XmlProfileExportEntity>? Entities { get; set; }
	}
}