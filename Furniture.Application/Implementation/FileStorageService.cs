using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Furniture.Application.Models.User;
using static Furniture.Utilities.Enums;

namespace Furniture.Application.Interfaces
{
    public class FileStorageService : IFileStorageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private const string USER_AVATAR_FOLDER_NAME = "images/avatar";
        private const string USER_DOCUMENT_FOLDER_NAME = "documents";

        public FileStorageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            //_userContentFolder = Path.Combine(webHostEnvironment.WebRootPath, USER_AVATAR_FOLDER_NAME);
        }

        public string GetFileUrl(string fileName)
        {
            return string.IsNullOrEmpty(fileName) ? string.Empty : $"/{USER_AVATAR_FOLDER_NAME}/{fileName}";
        }

        public async Task<string> SaveFileAsync(UserDocumentRequest request)
        {
            var userDocumentType = request.DocumentType == DocumentType.AVATAR.ToString() ? USER_AVATAR_FOLDER_NAME : USER_DOCUMENT_FOLDER_NAME;
            var userContentFolder = Path.Combine(_webHostEnvironment.WebRootPath, userDocumentType);
            var destPath = Path.Combine(userContentFolder, request.FileName);

            using (var fileStream = new FileStream(destPath, FileMode.Create, FileAccess.Write))
            {
                await request.Stream.CopyToAsync(fileStream);
            }

            return $"{request.Route}{userDocumentType}/{request.FileName}"; 
        }

        public async Task DeleteFileAsync(string fileName)
        {
            //var filePath = Path.Combine(_userContentFolder, fileName);
            //if (File.Exists(filePath))
            //{
            //    await Task.Run(() => File.Delete(filePath));
            //}

            await Task.Run(() => 1);
        }
    }
}