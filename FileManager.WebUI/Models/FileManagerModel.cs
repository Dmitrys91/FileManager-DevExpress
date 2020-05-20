using FileManager.Model.Commands;
using System.Collections.Generic;
using System.IO;

namespace FileManager.WebUI.Models
{
    public delegate void HandleOnFileUpload(Stream stream, string filePath);

    public class FileManagerModel
    {
        public FileManagerModel(HandleOnFileUpload uploadHandler, string rootPath)
        {
            FillCommands();
            UploadHandler = uploadHandler;
            RootPath = rootPath;
        }

        public HandleOnFileUpload UploadHandler { get; private set; }

        public string RootPath { get; private set; }

        public IEnumerable<IFileManagerCommand> Commands { get; private set; }

        private void FillCommands()
        {
            Commands = new List<IFileManagerCommand>()
            {
                new CopyFileCommand(),
                new CreateSubFolderCommand()
            };
        }
    }
}