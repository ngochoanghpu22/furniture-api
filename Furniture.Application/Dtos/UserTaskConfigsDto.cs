using System;
using System.Collections.Generic;
using System.Text;

namespace Furniture.Application.Dtos
{
    public class UserTaskConfigsDto
    {
        public int Id { get; set; }
        public int LevelId { get; set; } 
        public int TaskAmount { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
