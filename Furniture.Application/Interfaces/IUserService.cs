using System.Threading.Tasks;
using Furniture.Application.Dtos;
using Furniture.Application.Models.Common;
using Furniture.Application.Models.User;

namespace Furniture.Application.Interfaces
{
    public interface IUserService
    {
        Task<ApiResult<UserDto>> SignIn(LoginRequest request);
        Task<ApiResult<bool>> Signup(RegisterRequest request);
    }
}
