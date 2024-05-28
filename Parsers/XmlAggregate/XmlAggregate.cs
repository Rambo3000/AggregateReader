using System.Xml.Serialization;

namespace AggregateReader.Parsers.XmlAggregate
{
    [XmlRoot(ElementName = "aggregate")]
    public class XmlAggregate
    {
        [XmlAttribute(AttributeName = "type")]
        public required string Type { get; set; }

        [XmlElement(ElementName = "entity")]
        public List<XmlAggregateEntity> Entities { get; set; }

        public XmlAggregate()
        {
            Entities = [];
        }

        public override string ToString() { return Type; }
    }
}
