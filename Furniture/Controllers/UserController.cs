using HttpMultipartParser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Furniture.Api.Authorization;
using Furniture.Application.Interfaces;
using Furniture.Application.Models.User;
using Furniture.Utilities.Constants;
using Furniture.Utilities.Helpers;
using static Furniture.Utilities.Enums;

namespace Furniture.Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> Signup([FromBody] RegisterRequest request)
        {
            var result = await _userService.Signup(request);

            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn([FromBody] LoginRequest request)
        {
            var result = await _userService.SignIn(request);

            return Ok(result);
        }
    }
}