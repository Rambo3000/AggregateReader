namespace AggregateReader.DataProviders.RestServiceDataProvider
{
    public class RestServiceProviderFactory(UrlConfig urlConfig) : DataProviderFactory
    {
        public UrlConfig UrlConfig = urlConfig;

        public override IDataProvider CreateProvider()
        {
            return new RestServiceProvider(UrlConfig);
        }
    }
}
