using Newtonsoft.Json;

namespace AggregateReader.Config
{
    public static class ConfigManager
    {
        public static AggregateReaderConfig LoadConfig(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<AggregateReaderConfig>(json)?? new();
        }
    }
}
