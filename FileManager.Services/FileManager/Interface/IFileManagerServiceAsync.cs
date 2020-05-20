using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Services
{
    public interface IFileManagerServiceAsync
    {
        /// <summary>
        /// Copy file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Task<bool> CopyAsync(string filePath);

        /// <summary>
        /// Create subfolder of the selected folder
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        Task<string> CreateSubFolderAsync(string relativePath, string folderName);
    }
}
