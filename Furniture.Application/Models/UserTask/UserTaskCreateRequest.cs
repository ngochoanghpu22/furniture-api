using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Furniture.Application.Models.Task
{
    public class UserTaskCreateRequest
    {
        [Required]
        public int TaskId { get; set; }
        public string ImplementBy { get; set; } 
        public string Token { get; set; } 

        public bool IsPickedTask { get; set; }


    }
}
