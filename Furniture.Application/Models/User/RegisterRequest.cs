using AutoMapper.Configuration.Annotations;
using Furniture.Utilities.Constants;
using Furniture.Utilities.Helpers;

namespace Furniture.Application.Models.User
{
    public class RegisterRequest
    {
        public string Name { get; set; }
               
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}