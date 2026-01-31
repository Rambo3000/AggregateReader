using AggregateReader.BlueriqObjects;
using AggregateReader.Parsers.XmlAggregate;
using AggregateReader.Parsers.XmlProfileExport;

namespace AggregateReader.Parsers
{
    public static class ParserFactory
    {
        private static readonly List<IBlueriqParser> Parsers =
    [
        new ParserXmlProfileExportToBlueriqAggregate(),
        new ParserXmlAggregateToBlueriqAggregate()
    ];

        public static (BlueriqAggregate aggregate, IBlueriqParser parser) Parse(string xml)
        {
            foreach (var parser in Parsers)
            {
                if (parser.CanParse(xml))
                {
                    return (parser.Parse(xml), parser);
                }
            }

            throw new InvalidOperationException("No suitable parser found for the provided XML.");
        }
    }
}
