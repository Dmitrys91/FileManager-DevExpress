using FileManager.Model.Handlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileManager.Services.FileHandler
{
    public class FileHandlerService : FileHandlerServiceBase<IFileHandler>, IFileHandlerService
    {
        public void HandleOnDownload(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return;

            foreach(var handler in GetHandlers(filePath))
            {
                handler.HandleOnDownload(filePath);
            }
        }

        public void HandleOnUpload(Stream stream, string fileName)
        {
            if (string.IsNullOrEmpty(fileName) || stream is null)
                return;

            foreach (var handler in GetHandlers(fileName))
            {
                handler.HandleOnUpload(stream, fileName);
            }
        }

        public Task HandleOnUploadAsync(Stream stream, string fileName)
        {
            HandleOnUploadAsync(stream, fileName);
            return Task.FromResult(0);
        }

        public Task HandleOnDownloadAsync(string filePath)
        {
            HandleOnDownload(filePath);
            return Task.FromResult(0);
        }
    }
}
