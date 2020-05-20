using DevExpress.Web.Mvc;
using FileManager.Extensions;
using FileManager.Model;
using FileManager.WebUI.App_Start;
using FileManager.WebUI.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FileManager.WebUI
{
    public class MvcApplication : HttpApplication
    {
        private static readonly string _fileManagerFolderPath = FileManagerHelper.GetAbsolutePath(FileManagerConfig.FileManagerFolder);
        private static readonly string _rootFolderPath = FileManagerHelper.GetAbsolutePath(FileManagerConfig.RootFolder);

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.ashx/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new
                {
                    controller = "FileManager",
                    action = "Index",
                    id = string.Empty
                } 
            );
        }

        protected void Application_Start()
        {
            AutofacConfig.ConfigureContainer();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.DefaultBinder = new DevExpressEditorsBinder();
            DevExpress.Web.ASPxWebControl.CallbackError += new EventHandler(CallbackError);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            CreateFolders();
        }

        private void CreateFolders()
        {
            if (!Directory.Exists(_fileManagerFolderPath))
                Directory.CreateDirectory(_fileManagerFolderPath);

            if (!Directory.Exists(_rootFolderPath))
                Directory.CreateDirectory(_rootFolderPath);
        }

        void CallbackError(object sender, EventArgs e)
        {
            var exception = HttpContext.Current.Server.GetLastError();
            DevExpress.Web.ASPxWebControl.SetCallbackErrorMessage(exception.Message);
        }
    }
}
