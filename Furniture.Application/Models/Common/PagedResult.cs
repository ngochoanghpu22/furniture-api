using System;
using System.Collections.Generic;
using System.Text;

namespace Furniture.Application.Models.Common
{
    public class PagedResult<T> : PagedResultBase
    {
        public List<T> Items { set; get; }
    }
}