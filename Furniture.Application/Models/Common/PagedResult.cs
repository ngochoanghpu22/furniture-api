using System.Collections.Generic;

namespace Furniture.Application.Models.Common
{
    public class PagedResult<T> : PagedResultBase
    {
        public List<T> Items { set; get; }
    }
}