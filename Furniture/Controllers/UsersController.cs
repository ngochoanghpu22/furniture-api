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
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsersController(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           
            request.IpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            if (request.IpAddress == "::1")
            {
                request.IpAddress = CommonConstants.LocalIpAddress;
            }

            var result = await _userService.Register(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        
        [HttpGet]
        [Route("get-user-by-id")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetById(id);
            return Ok(user);
        }

        [HttpGet("search")]
        [FurnitureAuthorize(RoleConstants.AdminRoleName, RoleConstants.UserRoleName)]
        public async Task<IActionResult> SearchUser([FromQuery] GetUserPagingRequest request)
        {
            request.Role = FurnitureAuthenticationHandler.GetCurrentUser(_httpContextAccessor).Role;
            var users = await _userService.GetUsersPaging(request);
            return Ok(users);
        }

        [HttpPut]
        [Route("update-user")]
        public async Task<IActionResult> UpdateUserInfo([FromBody] UserUpdateRequest request)
        {
            request.UpdatedBy = FurnitureAuthenticationHandler.GetCurrentUser(_httpContextAccessor).UserName;
            var result = await _userService.UpdateInfo(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        
        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] UserPasswordChangeRequest request)
        {
            var result = await _userService.ChangePassword(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }
        
        [HttpPut("forgot-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var result = await _userService.ForgotPassword(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.Delete(id);
            return Ok(result);
        }
        
        [HttpPut("update-status")]
        [FurnitureAuthorize(RoleConstants.AdminRoleName, RoleConstants.UserRoleName)]
        public async Task<IActionResult> UpdateStatus([FromQuery] int userId, string status)
        {
            var currentUserName = FurnitureAuthenticationHandler.GetCurrentUser(_httpContextAccessor).UserName;
            var result = await _userService.UpdateStatus(userId, status, currentUserName);
            return Ok(result);
        }
        
        [HttpPut("update-avatar")]
        public async Task<IActionResult> UpdateAvatar()
        {
            var formData = MultipartFormDataParser.Parse(Request.BodyReader.AsStream());
            var filePart = formData.Files[0];

            UserDocumentRequest request = new UserDocumentRequest
            {
                Id = Convert.ToInt32(formData.GetParameterValue("userId")),
                DocumentType = DocumentType.AVATAR.ToString(),
                Route = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/",
                Stream = filePart.Data,
                FileName = $"{Guid.NewGuid()}_{filePart.FileName}"
            };

            var result = await _userService.UpdateAvatar(request);

            return Ok(result);
        }
        
        [HttpDelete("delete-avatar")]
        public async Task<IActionResult> DeleteAvatar(int id)
        {
            var result = await _userService.DeleteAvatar(id);
            return Ok(result);
        }
        
        [HttpGet("verify")]
        public ContentResult Verify()
        {
            var html = "<div id='actionElement'><div class='mdl - card mdl - shadow--2dp firebaseui-container firebaseui - id - page - email - verification - failure'><div class='firebaseui - card - header'><h1 class='firebaseui - title'>Your account has been Activated</h1></div><div class='firebaseui - card - content'><p class='firebaseui - text'>Your account has already been used</p></div><div class='firebaseui - card - actions'></div></div></div>";
            return base.Content(html, "text/html");
        }
        
        [HttpGet("active-user")]
        [AllowAnonymous]
        public ContentResult ActiveUser([FromQuery] string code)
        {
            string html = "";
            var result =  _userService.Activate(code);
            if (result.Result.IsSuccessed)
            {
                html = "<div id='actionElement'><div class='mdl - card mdl - shadow--2dp firebaseui-container firebaseui - id - page - email - verification - failure'><div class='firebaseui - card - header'><h1 class='firebaseui - title'>Your account has been Activated</h1></div><div class='firebaseui - card - content'><p class='firebaseui - text'>Your account has already been used</p></div><div class='firebaseui - card - actions'></div></div></div>";
            }
            else
            {
                 html = "<div>Failed ! Try verifying your email again.</div>";
            }
            return base.Content(html, "text/html");
        }

        [HttpGet("get-clients")]
        public async Task<IActionResult> GetClients()
        {
            var user = await _userService.GetClients();
            return Ok(user);
        }

    }
}