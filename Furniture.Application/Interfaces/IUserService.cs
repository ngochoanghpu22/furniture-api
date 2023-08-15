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
        Task<ApiResult<UserDto>> SignIn(LoginRequest request);
        Task<ApiResult<bool>> Signup(RegisterRequest request);
    }
}
