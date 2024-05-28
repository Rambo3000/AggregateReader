using AggregateReader.BlueriqObjects;

namespace AggregateReader.Parsers
{
    public static class BlueriqParserFactory
    {
        private static readonly List<IBlueriqParser> Parsers = new List<IBlueriqParser>
    {
        new BlueriqProfileExportXmlAggregateParser(),
        new BlueriqXmlAggregateParser()
    };

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
