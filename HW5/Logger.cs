namespace HW5
{
    public class Logger
    {
        private static Logger instance;
        private LoggerConfig _config;
        private FileService _fileService;
        private DateTime _date;
        private Logger(FileService fileService, string configPath)
        {
            _config = ConfigService.GetConfig(configPath);
            _fileService = fileService;
            _date = DateTime.Now;
            _fileService.CreateDirectory(_config.LogDirectory);
        }

        public enum Type
        {
            Info,
            Warning,
            Error
        }

        public static Logger GetInstance(FileService fileService, string configPath)
        {
            if (instance is null)
            {
                instance = new Logger(fileService, configPath);
            }

            return instance;
        }

        public void Write(Type type, string text)
        {
            string logText = $"{DateTime.Now.TimeOfDay}: {type}: {text}\n";
            Console.Write(logText);
            _fileService.Write($"{_config.LogDirectory}{_date.ToString(_config.TimeFormat)} {_date.ToShortDateString()}{_config.FileExtension}", logText);
        }

        public void CheckLogCount()
        {
            string[] logs = Directory.GetFiles(_config.LogDirectory);
            if (logs.Length > 3)
            {
                _fileService.Delete(logs[0]);
            }
        }
    }
}
