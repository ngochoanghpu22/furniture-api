using Microsoft.Extensions.Configuration;
using System;

namespace Furniture.Utilities.Helpers
{
    public static class EnvironmentConfig
    {
        public static string ConnectionString { get; private set; }

        public static string SecretKey { get; private set; }

        public static string Issuer { get; private set; }

        public static string Audience { get; private set; }

        public static int ExpirationInMinutes { get; private set; }

        public static void Config(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
            SecretKey = configuration["JwtConfig:SecretKey"];
            Issuer = configuration["JwtConfig:Issuer"];
            Audience = configuration["JwtConfig:Audience"];
            ExpirationInMinutes = Convert.ToInt32(configuration["JwtConfig:ExpirationInMinutes"]);
        }
    }
}
