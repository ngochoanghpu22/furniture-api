using System;
using System.Collections.Generic;
using System.Text;

namespace Furniture.Application.Models.Task
{
    public class TaskHistoryCreateRequest
    {
        public int TaskId { get; set; }
        public string ImplementBy { get; set; }
        public string Status { get; set; }

    }
}
