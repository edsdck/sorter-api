using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sorter.Shared.Interfaces;
using Sorter.Shared.Options;

namespace Sorter.Infrastructure
{
    public class FileManager : IFileManager, IDisposable
    {
        private readonly ReaderWriterLockSlim _writeLock = new();
        private readonly FileManagerOptions _fileManagerOptions;
        private readonly ILogger _logger;

        public FileManager(
            IOptions<FileManagerOptions> fileHandlingOptions,
            ILogger<FileManager> logger)
        {
            _fileManagerOptions = fileHandlingOptions.Value;
            _logger = logger;
        }

        public void Write(object data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            var serialized = JsonSerializer.Serialize(data);

            _ = _writeLock.TryEnterWriteLock(_fileManagerOptions.DefaultFileLockWaitMs);

            try
            {
                File.WriteAllText(_fileManagerOptions.DefaultFileName, serialized);
            }
            finally
            {
                _writeLock.ExitWriteLock();
            }
        }

        public T Read<T>()
        {
            _ = _writeLock.TryEnterReadLock(_fileManagerOptions.DefaultFileLockWaitMs);

            var data = string.Empty;
            try
            {
                data = File.ReadAllText(_fileManagerOptions.DefaultFileName);
            }
            catch (FileNotFoundException)
            {
                _logger.LogError("Result file was not found.");
            }
            finally
            {
                _writeLock.ExitReadLock();
            }

            return string.IsNullOrEmpty(data)
                ? default
                : JsonSerializer.Deserialize<T>(data);
        }

        public void Dispose()
        {
            _writeLock.Dispose();
        }
    }
}
