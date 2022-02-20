using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG.Presentation.Storage
{
    public interface IImageStorage
    {
        Task<string> EditFile(byte[] contents, string extension, string container, string route,
            string contentType);
        Task DeleteFile(string route, string container);
        Task<string> SaveFile(byte[] contents, string extension, string container, string contentType);
    }
}
