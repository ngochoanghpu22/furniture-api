using System;
using System.Collections.Generic;
using System.Text;
using Furniture.Application.Models.Common;

namespace Furniture.Application.Dtos
{
    public class UsersPickedTaskDto
    {
        public int TaskId { get; set; }

        public string TaskName { get; set; }

        public string ImplementedBy { get; set; }

        public string Status { get; set; }

        public string PickedDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
