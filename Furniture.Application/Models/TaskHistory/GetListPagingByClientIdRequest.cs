using System;
using System.Collections.Generic;
using System.Text;
using Furniture.Application.Models.Common;

namespace Furniture.Application.Models.Task
{
    public class GetListPagingByClientIdRequest : PagingRequestBase
    {
        public int ClientId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
