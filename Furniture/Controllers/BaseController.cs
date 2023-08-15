using Microsoft.AspNetCore.Mvc;
using Furniture.Api.Extensions;

namespace Furniture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public string GetUserId()
        {
            var userId = User.GetUserId();
            return userId;
        }

        [NonAction]
        public string GetUrl()
        {
            var route = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}";
            return route;
        }
    }
}
