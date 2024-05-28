using AggregateReader.BlueriqObjects;

namespace AggregateReader.Parsers
{
    public interface IBlueriqParser
    {
        bool CanParse(string xml);
        BlueriqAggregate Parse(string xml);
        bool CanIdentifyRootNodes { get; }
    }
}
