using System.Xml.Serialization;

namespace AggregateReader.Parsers.BlueriqXml
{
    [XmlRoot(ElementName = "entity")]
    public class BlueriqXmlEntity
    {
        [XmlAttribute(AttributeName = "type")]
        public string? Type { get; set; }

        [XmlAttribute(AttributeName = "root")]
        public required string Root { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string? Id { get; set; }

        [XmlElement(ElementName = "attribute")]
        public List<BlueriqXmlAttribute>? Attributes { get; set; }

        [XmlElement(ElementName = "relation")]
        public List<BlueriqXmlRelation>? Relations { get; set; }

        public override string ToString() { return Type ?? string.Empty; }
    }
}
