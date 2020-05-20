using FileManager.Extensions;
using FileManager.Model;
using FileManager.Services;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FileManager.WebUI.Controllers
{
    public class CommandController : Controller
    {
        private readonly IFileManagerService _fileManagerService;

        public CommandController(IFileManagerService fileManagerService)
        {
            _fileManagerService = fileManagerService;
        }

        [HttpPost]
        public async Task<ActionResult> Copy(string relativePath)
        {
            var result = await _fileManagerService.CopyAsync(FileManagerHelper.CreateFileFullPath(relativePath));
            return new HttpStatusCodeResult(result ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSubFolder(string relativePath, string folderName)
        {
            var fullPath = FileManagerHelper.CreateFileFullPath(relativePath);
            var result = await _fileManagerService.CreateSubFolderAsync(fullPath, folderName);
            return new HttpStatusCodeResult(!string.IsNullOrEmpty(result) ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        }
    } 
}