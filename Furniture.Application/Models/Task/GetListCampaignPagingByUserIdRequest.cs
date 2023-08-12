using System;
using System.Collections.Generic;
using System.Text;
using Furniture.Application.Models.Common;

namespace Furniture.Application.Models.Task
{
    public class GetListTaskPagingByUserIdRequest : PagedResultBase
    {
        public string OwnerBy { get; set; }
    }
}
