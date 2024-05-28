using System.Xml.Serialization;

namespace AggregateReader.Parsers.XmlProfileExport
{
    [XmlRoot("entity")]
    public class XmlProfileExportEntity
    {
        [XmlAttribute("instanceid")]
        public string? InstanceId { get; set; }

        [XmlAttribute("name")]
        public string? Name { get; set; }

        [XmlElement("attribute")]
        public List<XmlProfileExportAttribute>? Attributes { get; set; }
    }
}
