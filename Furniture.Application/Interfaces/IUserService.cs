using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Furniture.Application.Dtos;
using Furniture.Application.Models;
using Furniture.Application.Models.Common;
using Furniture.Application.Models.User;
using Furniture.Data.Entities;

namespace Furniture.Application.Interfaces
{
    public interface IUserService
    {
        Task<ApiResult<UserDto>> Authenticate(LoginRequest request);
        Task<ApiResult<bool>> Register(RegisterRequest request);
        Task<ApiResult<UserDto>> UpdateInfo(UserUpdateRequest request);
        Task<ApiResult<PagedResult<UserDto>>> GetUsersPaging(GetUserPagingRequest request);
        Task<ApiResult<UserDto>> GetById(int id);
        Task<ApiResult<List<UserDto>>> GetClients();
        Task<ApiResult<bool>> Delete(int id);
        Task<ApiResult<UserDto>> SearchUser(SearchUserRequest request);
        Task<ApiResult<bool>> ForgotPassword(ForgotPasswordRequest request);
        Task<ApiResult<bool>> ChangePassword(UserPasswordChangeRequest request);
        Task<ApiResult<bool>> UpdateStatus(int userId, string status, string updateBy);
        Task<ApiResult<string>> UpdateAvatar(UserDocumentRequest request);
        Task<ApiResult<bool>> DeleteAvatar(int id);
        Task<ApiResult<string>> Activate(string code);
    }
}
