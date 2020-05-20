using System.IO;

namespace FileManager.Model.Handlers.Common
{
    public class CommonFileHandler : IFileHandler
    {
        public string[] AllowedExtensions => new string[] { ".jpg", ".jpeg", ".gif", ".rtf", ".txt", ".avi", ".png", ".mp3", ".xml", ".doc", ".pdf" };

        public void HandleOnDownload(string filePath)
        {
            // .. do some stuff
        }

        public void HandleOnUpload(Stream stream, string fileName)
        {
            // .. do some stuff
        }
    }
}
