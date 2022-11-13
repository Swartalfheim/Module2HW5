namespace HW5
{
    public class FileService
    {
        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public void Write(string path, string text)
        {
            File.AppendAllText(path, text);
        }

        public void Delete(string path)
        {
            File.Delete(path);
        }
    }
}
