using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Services
{
    public interface IFileManagerService : IFileManagerServiceAsync
    {
        /// <summary>
        /// Copy file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        bool Copy(string filePath);

        /// <summary>
        /// Create subfolder of the selected folder
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        string CreateSubFolder(string relativePath, string folderName);
    }
}
