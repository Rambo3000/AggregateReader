using AggregateReader.DataProviders.RestServiceDataProvider;

namespace AggregateReader.DataProviders
{
    public abstract class DataProviderFactory
    {
        public abstract IDataProvider CreateProvider();
    }
}
