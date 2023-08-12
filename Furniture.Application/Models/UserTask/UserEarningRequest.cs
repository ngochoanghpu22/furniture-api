using System;
using System.Collections.Generic;
using System.Text;

namespace Furniture.Application.Models.UserTask
{
    public class UserEarningRequest
    {
        public string UserName { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
