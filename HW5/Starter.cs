using HW5;

namespace HWen
{
    public class Starter
    {
        private readonly FileService _fileService;
        private readonly Logger _logger;
        private readonly Actions _actions;
        private readonly Random _random;
        public Starter()
        {
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            _fileService = new FileService();
            _logger = Logger.GetInstance(_fileService, $"{projectDirectory}/logger_config.json");
            _actions = new Actions(_fileService, $"{projectDirectory}/logger_config.json");
            _random = new Random();
        }

        public void Run()
        {
            for (int i = 0; i < 100; i++)
            {
                int method = _random.Next(1, 99 + 1);
                try
                {
                    if (method < 80)
                    {
                        _actions.Method200();
                    }
                    else if (method < 95)
                    {
                        _actions.Method300();
                    }
                    else
                    {
                        _actions.Method400();
                    }
                }
                catch (BusinessException ex)
                {
                    _logger.Write(Logger.Type.Warning, $"Action got this custom Exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    _logger.Write(Logger.Type.Error, $"Action failed by reason: {ex}");
                }
            }

            _logger.CheckLogCount();
        }
    }
}
