using Furniture.Application.Dtos;
using Furniture.Application.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furniture.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<ApiResult<List<CategoryDto>>> GetCategories();
    }
}
