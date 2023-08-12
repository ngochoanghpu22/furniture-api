using Furniture.Application.Dtos;
using System.Threading.Tasks;

namespace Furniture.Application.Interfaces
{
    public interface IAuthorizationService
    {
        Task<UserDto> GetUserAsync(string token);
    }
}
