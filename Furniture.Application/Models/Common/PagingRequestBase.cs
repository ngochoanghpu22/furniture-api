namespace Furniture.Application.Models.Common
{
    public class PagingRequestBase
    {
        public string Role { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public string SortProp { get; set; }

        private string _sortOrder;
        public string SortOrder
        {
            get
            {
                return _sortOrder.ToUpper();
            }
            set { _sortOrder = value; }
        }
    }
}