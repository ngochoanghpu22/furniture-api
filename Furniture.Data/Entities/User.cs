using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Furniture.Data.Interfaces;

namespace Furniture.Data.Entities
{
    public class User : DomainEntity<int>, ITracking, ISwitchable
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string Phone { get; set; }

        public string Avatar { get; set; }

        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }
        
        public DateTime? UpdatedDate { get; set; }
        
        public string CreatedBy { get; set; }
        
        public string UpdatedBy { get; set; }

        public string Status { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
