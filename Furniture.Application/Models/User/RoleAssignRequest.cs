using System;
using System.Collections.Generic;
using System.Text;
using Furniture.Application.Models.Common;

namespace Furniture.Application.Models.User
{
    public class RoleAssignRequest
    {
        public Guid Id { get; set; }
        public List<SelectItem> Roles { get; set; } = new List<SelectItem>();
    }
}