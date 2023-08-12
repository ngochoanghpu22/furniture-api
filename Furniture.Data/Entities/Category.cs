using Furniture.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace Furniture.Data.Entities
{
    public class Category : DomainEntity<int>, ITracking, ISwitchable
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public int DisplayOrder { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public string Status { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
