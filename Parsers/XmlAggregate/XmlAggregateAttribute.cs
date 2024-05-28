using System.Xml.Serialization;

namespace AggregateReader.Parsers.XmlAggregate
{
    public class XmlAggregateAttribute
    {
        [XmlAttribute(AttributeName = "name")]
        public required string Name { get; set; }

        [XmlAttribute(AttributeName = "multivalue")]
        public required string Multivalue { get; set; }

        [XmlText]
        public string? Value { get; set; }

        [XmlElement(ElementName = "value")]
        public List<string>? Values { get; set; }

        public override string ToString() { return Name; }
    }
}
