using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Furniture.Utilities.Constants;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Furniture.Api.Authorization
{
    public class FurnitureAuthorizeAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        public new string[] Roles { get; private set; }

        public FurnitureAuthorizeAttribute(params string[] roles) : base()
        {
            Roles = roles ?? throw new ArgumentNullException(nameof(roles));
        }

        public virtual async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var isAuthenticated = context.HttpContext.User.Identity.IsAuthenticated;
            if (!isAuthenticated)
            {
                var unauthorizedResult = new ObjectResult(new
                {
                    Message = "Access Denied",
                    StatusCode = HttpStatusCode.Unauthorized
                });

                context.Result = unauthorizedResult;
                return;
            }

            var forbidResult = new ObjectResult(new
            {
                Message = "You do not have permission to perform this action",
                StatusCode = HttpStatusCode.Forbidden
            });

            var rolesClaim = context.HttpContext.User.FindFirst(c => c.Type == ClaimConstants.Role)?.Value;

            if (string.IsNullOrEmpty(rolesClaim))
            {
                context.Result = forbidResult;
                return;
            }

            var permissionClaimList = rolesClaim.Split(';').ToList();
            foreach (var role in Roles)
            {
                if (permissionClaimList.Any(p => string.Equals(p, role, StringComparison.InvariantCultureIgnoreCase)))
                {
                    return;
                }
            }

            context.Result = forbidResult;
            await Task.CompletedTask;
        }
    }
}
