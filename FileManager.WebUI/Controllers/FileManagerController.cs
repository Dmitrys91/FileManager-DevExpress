using DevExpress.Web.Mvc;
using FileManager.Extensions;
using FileManager.Services;
using FileManager.Services.FileHandler;
using FileManager.WebUI.Extensions;
using FileManager.WebUI.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FileManager.WebUI.Controllers
{
    public class FileManagerController : Controller
    {
        private readonly IFileManagerService _fileManagerService;
        private readonly IFileHandlerService _fileHandlerService;

        public FileManagerController(IFileManagerService fileManagerService,
            IFileHandlerService fileHandlerService)
        {
            _fileManagerService = fileManagerService;
            _fileHandlerService = fileHandlerService;
        }

        public ActionResult Index()
        {
            return View(CreateModel());
        }

        [ValidateInput(false)]
        public ActionResult CallBackPartial()
        {
            return PartialView(CreateModel());
        }

        public ActionResult CustomToolbarAction(string relativePath)
        {
            return PartialView(nameof(CallBackPartial), CreateModel());
        }
        public async Task<FileStreamResult> DownloadFiles(string downloadPath)
        {
            await _fileHandlerService.HandleOnDownloadAsync(downloadPath);

            return FileManagerExtension.DownloadFiles(FileManagerHelper.CreateFileManagerDownloadSettings(), FileManagerConfig.RootFolder);
        }

        private FileManagerModel CreateModel()
        {
            var model = new FileManagerModel(_fileHandlerService.HandleOnUpload, FileManagerConfig.RootFolder);
            return model;
        }
    }
}