using Furniture.Application.Dtos;
using Furniture.Application.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furniture.Application.Interfaces
{
    public interface IProductService
    {
        Task<ApiResult<List<ProductDto>>> GetProducts(int categoryId);

        Task<ApiResult<ProductDto>> GetProductDetail(int productId);
    }
}
