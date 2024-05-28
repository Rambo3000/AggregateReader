using System.Xml.Serialization;

namespace AggregateReader.Parsers.XmlProfileExport
{
    [XmlRoot("attribute")]
    public class XmlProfileExportAttribute
    {
        [XmlAttribute("name")]
        public string? Name { get; set; }

        [XmlAttribute("source")]
        public string? Source { get; set; }

        [XmlElement("value")]
        public List<string>? Values { get; set; }

        [XmlText]
        public string? Value { get; set; }

        public bool ShouldSerializeValues() => Values != null && Values.Count > 0;
        public bool ShouldSerializeValue() => !ShouldSerializeValues();
    }
}
