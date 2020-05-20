using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FileManager.Services.FileHandler
{
    public interface IFileHandlerServiceAsync
    {
        Task HandleOnUploadAsync(Stream stream, string fileName);

        Task HandleOnDownloadAsync(string filePath);
    }
}
