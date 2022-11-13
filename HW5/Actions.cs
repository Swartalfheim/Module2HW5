namespace HW5
{
    public class Actions
    {
        private readonly Logger _logger;
        public Actions(FileService fileService, string configPath)
        {
            _logger = Logger.GetInstance(fileService, configPath);
        }

        public bool Method200()
        {
            _logger.Write(Logger.Type.Info, "Start method: Method200()");
            return true;
        }

        public bool Method300()
        {
            throw new BusinessException("Skipped logic in method: Method300");
        }

        public bool Method400()
        {
            throw new Exception("I broke a logic");
        }
    }
}
