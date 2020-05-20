using Model.Handlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Services.FileHandler
{
    public abstract class FileHandlerServiceBase<T> where T: IBaseFileHandler
    {
        protected List<T> GetHandlers(string fileName)
        {
            var extension = Path.GetExtension(fileName);

            var type = typeof(T);

            var handlerTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.IsClass);

            List<T> handlers = new List<T>();

            if (!handlerTypes.Any())
                return handlers;

            foreach (var handlerType in handlerTypes)
            {
                if (Activator.CreateInstance(handlerType) is T handler && handler.AllowedExtensions.Contains(extension))
                {
                    handlers.Add(handler);
                }
            }

            return handlers;
        }
    }
}
