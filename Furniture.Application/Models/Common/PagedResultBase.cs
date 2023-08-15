using System;

namespace Furniture.Application.Models.Common
{
    public class PagedResultBase
    {
        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int PageNumber { get; set; } = 1;

        public int TotalPages
        {
            get
            {
                var pageCount = (double)TotalCount / PageSize;
                return (int)Math.Ceiling(pageCount);
            }
        }
    }
}