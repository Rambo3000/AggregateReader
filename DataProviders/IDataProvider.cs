using AggregateReader.DataProviders.RestServiceDataProvider;

namespace AggregateReader.DataProviders
{
    public interface IDataProvider
    {
        Task<string> GetDataAsync(string id);
    }
}
