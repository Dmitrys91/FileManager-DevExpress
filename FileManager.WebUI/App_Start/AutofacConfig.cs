using Autofac;
using Autofac.Integration.Mvc;
using FileManager.Model;
using FileManager.Services;
using FileManager.Services.FileHandler;
using FileManager.WebUI.Models;
using System.Web.Mvc;

namespace FileManager.WebUI.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<FileManagerService>().As<IFileManagerService>();
            builder.RegisterType<FileHandlerService>().As<IFileHandlerService>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}