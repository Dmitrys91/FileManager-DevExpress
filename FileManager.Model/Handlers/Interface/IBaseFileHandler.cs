using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Handlers
{
    public interface IBaseFileHandler
    {
        /// <summary>
        /// Allowed Extensions of files
        /// </summary>
        string[] AllowedExtensions { get; }

        /// <summary>
        /// Handle upload event
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="fileName"></param>
        void HandleOnUpload(Stream stream, string fileName);

        /// <summary>
        /// Handle download event
        /// </summary>
        /// <param name="filePath"></param>
        void HandleOnDownload(string filePath);
    }
}
