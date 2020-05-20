using System.Collections.Generic;
using System.IO;

namespace FileManager.Services.FileHandler
{
    public interface IFileHandlerService : IFileHandlerServiceAsync
    {
        void HandleOnUpload(Stream stream, string fileName);

        void HandleOnDownload(string filePath);
    }
}
