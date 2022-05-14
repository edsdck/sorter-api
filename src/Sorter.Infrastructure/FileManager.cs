using System.Text.Json;
using Microsoft.Extensions.Options;
using Sorter.Api;

namespace Sorter.Infrastructure
{
    public class FileManager : IFileManager, IDisposable
    {
        private readonly ReaderWriterLockSlim _writeLock = new();
        private readonly FileManagerOptions _fileHandlingOptions;

        public FileManager(IOptions<FileManagerOptions> fileHandlingOptions)
        {
            _fileHandlingOptions = fileHandlingOptions.Value;
        }

        public void Write(object data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            var serialized = JsonSerializer.Serialize(data);

            _ = _writeLock.TryEnterWriteLock(_fileHandlingOptions.DefaultFileLockMs);

            try
            {
                File.WriteAllText(_fileHandlingOptions.DefaultFileName, serialized);
            }
            finally
            {
                _writeLock.ExitWriteLock();
            }
        }

        public T Read<T>()
        {
            _ = _writeLock.TryEnterReadLock(_fileHandlingOptions.DefaultFileLockMs);

            var data = string.Empty;
            try
            {
                data = File.ReadAllText(_fileHandlingOptions.DefaultFileName);
            }
            finally
            {
                _writeLock.ExitReadLock();
            }

            return JsonSerializer.Deserialize<T>(data);
        }

        public void Dispose()
        {
            _writeLock.Dispose();
        }
    }
}
