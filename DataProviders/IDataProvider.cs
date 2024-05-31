using AggregateReader.DataProviders.RestServiceDataProvider;

namespace AggregateReader.DataProviders
{
    public interface IDataProvider
    {
        UrlConfig UrlConfig { get; }
        Task<string> GetDataAsync(string id);
    }
}
