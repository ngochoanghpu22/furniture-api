using Furniture.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace Furniture.Data.Entities
{
    public class OrderDetail : DomainEntity<int>, ITracking
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public virtual Order Order { get; set; }
    }
}
