using Microsoft.Extensions.Configuration;
using Furniture.Application.Interfaces;
using System;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Furniture.Application.Models.Common;
using System.Net;
using Microsoft.IdentityModel.Tokens;
using Furniture.Utilities.Helpers;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using Furniture.Api.Extensions;
using Furniture.Application.Models.Claim;
using Furniture.Utilities.Constants;

namespace Furniture.Api.Authorization
{
    public class FurnitureAuthenticationHandler : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string token = context.HttpContext.Request.Headers["Authorization"].ToString();

            if (string.IsNullOrWhiteSpace(token))
            {
                var responseAPI = new ApiErrorResult<string>("Lỗi xác thực");
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new JsonResult(responseAPI);
            }
            else
            {
                try
                {
                    string tokenValue = token.Replace("Bearer", string.Empty).Trim();
                    ClaimsPrincipal claimsPrincipal = DecodeJWTToken(tokenValue, EnvironmentConfig.SecretKey);
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                }
                catch (SecurityTokenExpiredException ex)
                {
                    var responseAPI = new ApiErrorResult<string>("Hết phiên đăng nhập");
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
                    context.Result = new JsonResult(responseAPI);
                }
                catch (Exception ex)
                {
                    var responseAPI = new ApiErrorResult<string>("Lỗi xác thực");
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    context.Result = new JsonResult(responseAPI);
                }
            }
        }

        public static ClaimModel GetCurrentUser(IHttpContextAccessor context)
        {
            try
            {
                var userSession = new ClaimModel();

                string token = context.HttpContext.Request.Headers[CommonConstants.Authorization].ToString();
                string tokenValue = token.Replace(CommonConstants.BearerSchema, string.Empty).Trim();

                ClaimsPrincipal claimsPrincipal = DecodeJWTToken(tokenValue, EnvironmentConfig.SecretKey);
                if (claimsPrincipal != null)
                {
                    userSession.UserId = claimsPrincipal.GetSpecificClaim(ClaimConstants.UserId);
                    userSession.Email = claimsPrincipal.GetSpecificClaim(ClaimConstants.Email);
                    userSession.Role = claimsPrincipal.GetSpecificClaim(ClaimConstants.Role);
                    userSession.UserName = claimsPrincipal.GetSpecificClaim(ClaimConstants.UserName);
                }

                return userSession;
            }
            catch
            {
                throw new ArgumentException("Lỗi xác thực");
            }
        }

        public static ClaimsPrincipal DecodeJWTToken(string token, string secretAuthKey)
        {
            var key = Encoding.ASCII.GetBytes(secretAuthKey);
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var claims = handler.ValidateToken(token, validations, out var tokenSecure);
            return claims;
        }
    }
    public class SystemAuthorizeAttribute : TypeFilterAttribute
    {
        public SystemAuthorizeAttribute() : base(typeof(FurnitureAuthenticationHandler))
        {
        }
    }
}
