﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Furniture.Application.Models.User
{
    public class RegisterRequest
    {
        [Required]
        public string Name { get; set; }
       
        //[Required]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required]
        public string UserName { get; set; }

        public int Level { get; set; }

        public decimal Balance { get; set; }

        [Required]
        public string Password { get; set; }

        //[Required]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
        //[Required]
        public string IpAddress { get; set; }
        [Required]
        public string Role { get; set; }
        public string Gender { get; set; }
        //public string Avatar { get; set; }
    }
}