
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileManager.Services
{
    public class FileManagerService : IFileManagerService
    {
        private readonly string _copyFileTemplate = "Copy of {0}{1}";

        public FileManagerService() { }
        public bool Copy(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return false;

            try
            {
                string sourceFileName = filePath;
                string sourceDirectory = Path.GetDirectoryName(sourceFileName);
                string filenameWithoutExtension = Path.GetFileNameWithoutExtension(sourceFileName);
                string fileExtension = Path.GetExtension(sourceFileName);
                string copyFileName = string.Format(_copyFileTemplate, filenameWithoutExtension, fileExtension);
                string destFileName = Path.Combine(sourceDirectory, copyFileName);

                destFileName = GenerateUniqueFileName(destFileName);

                FileAttributes attr = File.GetAttributes(sourceFileName);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    CopyFolder(sourceFileName, destFileName);
                }
                else
                {
                    File.Copy(sourceFileName, destFileName);
                }

                return true;
            }
            catch(Exception ex)
            {
                //.. Log exception
                return false;
            }
        }

        private void CopyFolder(string SourcePath, string DestinationPath)
        {
            var directories = Directory.GetDirectories(SourcePath, "*", SearchOption.AllDirectories);
            var files = Directory.GetFiles(SourcePath, "*.*", SearchOption.AllDirectories);

            DestinationPath = GenerateUniqueFileName(DestinationPath, true);

            if (!directories.Any())
            {
                Directory.CreateDirectory(DestinationPath);
            }

            //Now Create all of the directories
            foreach (string dirPath in directories)
            {
                Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in files)
            {
                File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);
            }
        }

        public string CreateSubFolder(string relativePath, string folderName)
        {
            try
            {
                string destFolderName = GenerateUniqueFileName(Path.Combine(relativePath, folderName));
                if (!Directory.Exists(destFolderName))
                {
                    var directory = Directory.CreateDirectory(destFolderName);

                    return directory.FullName;
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                //.. Log exception
                return string.Empty;
            }
        }

        private string GenerateUniqueFileName(string fileName, bool isFolder = false)
        {
            int i = 0;

            if (isFolder)
            {
                while (Directory.Exists(fileName))
                {
                    if (i == 0)
                        fileName = fileName.Replace(fileName, fileName + "(" + ++i + ")");
                    else
                        fileName = fileName.Replace("(" + i + ")", "(" + ++i + ")");
                }
            }
            else
            {
                string extension = Path.GetExtension(fileName);

                while (File.Exists(fileName))
                {
                    if (i == 0)
                        fileName = fileName.Replace(extension, "(" + ++i + ")" + extension);
                    else
                        fileName = fileName.Replace("(" + i + ")" + extension, "(" + ++i + ")" + extension);
                }
            }

            return fileName;
        }

        public async Task<bool> CopyAsync(string filePath)
        {
            return await Task.FromResult(Copy(filePath));
        }

        public async Task<string> CreateSubFolderAsync(string relativePath, string folderName)
        {
            return await Task.FromResult(CreateSubFolder(relativePath, folderName));
        }
    }
}
