﻿using System.Text.Json;
using Microsoft.Extensions.Options;
using Sorter.Shared.Interfaces;
using Sorter.Shared.Options;

namespace Sorter.Infrastructure
{
    public class FileManager : IFileManager, IDisposable
    {
        private readonly ReaderWriterLockSlim _writeLock = new();
        private readonly FileManagerOptions _fileManagerOptions;

        public FileManager(IOptions<FileManagerOptions> fileHandlingOptions)
        {
            _fileManagerOptions = fileHandlingOptions.Value;
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
