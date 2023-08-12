


using Furniture.Application.Models.Common;

namespace Furniture.Application.Models.User
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}