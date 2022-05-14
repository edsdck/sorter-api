namespace Sorter.Api
{
    public class FileManagerOptions
    {
        public const string FileManager = "FileManager";

        public int DefaultFileLockMs { get; set; }

        public string DefaultFileName { get; set; }
    }
}
