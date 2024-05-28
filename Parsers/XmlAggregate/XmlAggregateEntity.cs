using System.Xml.Serialization;

namespace AggregateReader.Parsers.XmlAggregate
{
    [XmlRoot(ElementName = "entity")]
    public class XmlAggregateEntity
    {
        [XmlAttribute(AttributeName = "type")]
        public string? Type { get; set; }

        [XmlAttribute(AttributeName = "root")]
        public required string Root { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string? Id { get; set; }

        [XmlElement(ElementName = "attribute")]
        public List<XmlAggregateAttribute>? Attributes { get; set; }

        [XmlElement(ElementName = "relation")]
        public List<XmlAggregateRelation>? Relations { get; set; }

        public override string ToString() { return Type ?? string.Empty; }
    }
}
