namespace AggregateReader.DataProviders.RestServiceDataProvider
{
    public class UrlConfig
    {
        public string? Name { get; set; }
        public string? Method { get; set; }
        public string? Url { get; set; }
        public string? JsonPath { get; set; }
        public string? BodyTemplate { get; set; }
        public string? ParameterName { get; set; }
    }
}
