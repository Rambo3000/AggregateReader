using System.Xml.Serialization;

namespace AggregateReader.Parsers.BlueriqXml
{
    [XmlRoot(ElementName = "aggregate")]
    public class BlueriqXmlAggregate
    {
        [XmlAttribute(AttributeName = "type")]
        public required string Type { get; set; }

        [XmlElement(ElementName = "entity")]
        public List<BlueriqXmlEntity> Entities { get; set; }

        public BlueriqXmlAggregate()
        {
            Entities = [];
        }

        public override string ToString() { return Type; }
    }
}
