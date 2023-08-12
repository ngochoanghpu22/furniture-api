using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Furniture.Application.Dtos;
using Furniture.Application.Interfaces;
using Furniture.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Application.Implementation
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthorizationService> _logger;

        public AuthorizationService(IConfiguration configuration, ILogger<AuthorizationService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<UserDto> GetUserAsync(string token)
        {
            try
            {
                var httpClient = HttpClientExtensions.ARMClient(_configuration, token);
                var endpoint = $"{_configuration["ARM:BaseUrl"]}{_configuration["ARM:Endpoint:Profile"]}";
                var user = await HttpClientExtensions.GetAsync<UserDto>(httpClient, endpoint, null);

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetUserAsync : {ex.Message}");
                _logger.LogError($"GetUserAsync : {ex.StackTrace}");
                return new UserDto();
            }
        }
    }
}
