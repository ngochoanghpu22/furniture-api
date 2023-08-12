using System;
using System.Collections.Generic;
using System.Text;

namespace Furniture.Application.Dtos
{
    public class TaskHistoryClientDto
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Name { get; set; }
        public decimal BidPerTaskCompletion { get; set; }
        public decimal Budget { get; set; }
        public decimal RemainingBudget { get; set; }
        public int TotalFinishedTask { get; set; }
        public string OwnerBy { get; set; }
        public string ImplementedBy { get; set; }
        public DateTime ImplementedDate { get; set; }
        public string TaskStatus { get; set; }

    }
}
