using Furniture.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace Furniture.Data.Entities
{
    public class AboutUs : DomainEntity<int>, ITracking
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Logo { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }
    }
}
