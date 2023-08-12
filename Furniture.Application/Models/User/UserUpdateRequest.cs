﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Furniture.Application.Models.User
{
    public class UserUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public IFormFile Avatar { get; set; }
        public string Address { get; set; }
        public string UpdatedBy { get; set; }
    }
}