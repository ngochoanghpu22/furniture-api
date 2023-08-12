using Furniture.Data.Interfaces;
using System;

namespace Furniture.Data.Entities
{
    public class Product : DomainEntity<int>, ITracking, ISwitchable
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public int QuantityInStock { get; set; }

        public int DisplayOrder { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public string Status { get; set; }

        public virtual Category Category { set; get; }
    }
}
