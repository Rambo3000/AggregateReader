using AggregateReader.DataProviders;
using Newtonsoft.Json;

namespace AggregateReader.Config
{
    public static class ConfigManager
    {
        public static DataProviders.AggregateReaderConfig LoadConfig(string filePath)
        {
            string json = File.ReadAllText(filePath);
            if (json == null) return null;
            return JsonConvert.DeserializeObject<AggregateReaderConfig>(json);
        }
    }
}
