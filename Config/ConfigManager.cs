using Newtonsoft.Json;

namespace AggregateReader.Config
{
    public static class ConfigManager
    {
        public static readonly string filePath = "AggregateReaderConfig.json";
        public static AggregateReaderConfig LoadConfig()
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<AggregateReaderConfig>(json)?? new();
        }
        public static void SaveConfig(AggregateReaderConfig config)
        {
            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}
