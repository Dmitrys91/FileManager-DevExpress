
namespace FileManager.WebUI.Extensions
{
    public class FileManagerConfig
    {
        public static string RootFolder = System.Configuration.ConfigurationManager.AppSettings["RootFolder"];

        public static string FileManagerFolder = System.Configuration.ConfigurationManager.AppSettings["FileManagerFolder"];
    }
}