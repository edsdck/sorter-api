namespace Sorter.Api
{
    public class FileManagerOptions
    {
        public const string FileHandling = "FileHandling";

        public int DefaultFileLockMs { get; set; }

        public string DefaultFileName { get; set; }
    }
}
