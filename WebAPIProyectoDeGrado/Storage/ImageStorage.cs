using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace PG.Presentation.Storage
{
    public class ImageStorage : IImageStorage
    {
        private readonly IWebHostEnvironment env;
        private readonly IHttpContextAccessor httpContextAccessor;
        public ImageStorage(IWebHostEnvironment env,
            IHttpContextAccessor httpContextAccessor)
        {
            this.env = env;
            this.httpContextAccessor = httpContextAccessor;
        }
        public Task DeleteFile(string route, string container)
        {
            if (route != null)
            {
                var fileName = Path.GetFileName(route);
                string directorioArchivo = Path.Combine(env.WebRootPath, container, fileName);

                if (File.Exists(directorioArchivo))
                {
                    File.Delete(directorioArchivo);
                }
            }

            return Task.FromResult(0);
        }

        public async Task<string> EditFile(byte[] contents, string extension, string container, string route, string contentType)
        {
            await DeleteFile(route, container);
            return await SaveFile(contents, extension, container, contentType);
        }

        public async Task<string> SaveFile(byte[] contents, string extension, string container, string contentType)
        {
            var fileName = $"{Guid.NewGuid()}{extension}";
            string folder = Path.Combine(env.WebRootPath, container);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string route = Path.Combine(folder, fileName);
            await File.WriteAllBytesAsync(route, contents);
            
            var url = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}";
            var urlToDB = Path.Combine(url, container, fileName).Replace("\\", "/");

            return urlToDB;
        }
    }
}
