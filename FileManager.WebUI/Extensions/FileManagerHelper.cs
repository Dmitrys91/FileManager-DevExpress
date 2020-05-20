using DevExpress.Web;
using FileManager.WebUI.Extensions;
using System.IO;
using System.Web;

namespace FileManager.Extensions
{
    public class FileManagerHelper
    {
        /// <summary>
        /// Create Full file path, based on the Web App domain
        /// </summary>
        /// <param name="relativePath"></param>
        /// <returns></returns>
        public static string CreateFileFullPath(string relativePath)
        {
            var managerFolder = HttpRuntime.AppDomainAppPath + FileManagerConfig.FileManagerFolder.Replace("~", string.Empty).Replace("/", "\\");
            var path = Path.Combine(managerFolder, relativePath);

            return path;
        }

        public static string GetAbsolutePath(string path)
        {
            return HttpRuntime.AppDomainAppPath + path.Replace("~", string.Empty).Replace("/", "\\");
        }

        public static DevExpress.Web.Mvc.FileManagerSettings CreateFileManagerDownloadSettings()
        {
            return CreateFileManagerDownloadSettingsCore(new FileManagerSettingsEditing(null)
            {
                AllowCreate = true,
                AllowMove = true,
                AllowDelete = true,
                AllowRename = true,
                AllowCopy = true,
                AllowDownload = true
            });
        }

        static DevExpress.Web.Mvc.FileManagerSettings CreateFileManagerDownloadSettingsCore(FileManagerSettingsEditing editingSettings)
        {
            var settings = new DevExpress.Web.Mvc.FileManagerSettings();
            settings.SettingsEditing.Assign(editingSettings);
            settings.Name = "fileManager";
            return settings;
        }
    }
}
