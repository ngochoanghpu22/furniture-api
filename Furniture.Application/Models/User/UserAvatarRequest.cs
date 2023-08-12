using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Furniture.Application.Models.User
{
    public class UserDocumentRequest
    {
        public int Id { get; set; }

        public Stream Stream { get; set; }

        public string FileName { get; set; }

        public string Route { get; set; }

        public string DocumentType { get; set; } 
    }
}
