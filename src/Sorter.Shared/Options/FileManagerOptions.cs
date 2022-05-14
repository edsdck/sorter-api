namespace Sorter.Shared.Options
{
    public class FileManagerOptions
    {
        public const string FileManager = "FileManager";

        public int DefaultFileLockWaitMs { get; set; }

        public string DefaultFileName { get; set; }
    }
}
