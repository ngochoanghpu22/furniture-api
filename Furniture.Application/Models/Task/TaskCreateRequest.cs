﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Furniture.Application.Models.Task
{
    public class TaskCreateRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int AverageCompletionTime { get; set; }
        public decimal BidPerTaskCompletion { get; set; }
        public decimal Budget { get; set; }
        public string Document { get; set; }
        public string LinkYoutube { get; set; }
        public string Guideline { get; set; }
        public string LinkPage { get; set; }
        public int DurationOnPage { get; set; }
        public string Status { get; set; }
        public string OwnerBy { get; set; } 
        public string CreatedBy { get; set; }


    }
}
