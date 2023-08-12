using System;
using System.Collections.Generic;
using System.Text;

namespace Furniture.Application.Dtos
{
    public class TaskHistoryDto
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public decimal BidPerTaskCompletion { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        
    }
}
