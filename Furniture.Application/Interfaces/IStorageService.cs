using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Furniture.Application.Models.User;

namespace Furniture.Application.Interfaces
{
    public interface IFileStorageService
    {
        string GetFileUrl(string fileName);

        Task<string> SaveFileAsync(UserDocumentRequest request);

        Task DeleteFileAsync(string fileName);
    }
}