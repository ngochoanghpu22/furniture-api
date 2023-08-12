using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Furniture.Application.Interfaces;
using Furniture.Application.Models.User;


namespace Furniture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _userService.Authenticate(request);

            return Ok(result);
        }
    }
}
