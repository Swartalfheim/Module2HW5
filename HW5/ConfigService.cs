using Newtonsoft.Json;

namespace HW5
{
    public static class ConfigService
    {
        public static LoggerConfig GetConfig(string path)
        {
            LoggerConfig cfg = JsonConvert.DeserializeObject<LoggerConfig>(File.ReadAllText(path));
            return cfg;
        }
    }
}
