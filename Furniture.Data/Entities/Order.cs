using Furniture.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace Furniture.Data.Entities
{
    public class Order : DomainEntity<int>, ITracking, ISwitchable
    {
        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public string Status { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
