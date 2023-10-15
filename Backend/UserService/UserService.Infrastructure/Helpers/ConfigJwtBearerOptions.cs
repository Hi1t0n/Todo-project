using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Infrastructure.Helpers
{
    public class ConfigJwtBearerOptions
    {
        public static void ConfigureJwtBearerOptions(JwtBearerOptions options)
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = JwtBearerTokenOptions.ISSUER,
                ValidateAudience = true,
                ValidAudience = JwtBearerTokenOptions.AUDIENCE,
                ValidateLifetime = true,
                IssuerSigningKey = JwtBearerTokenOptions.GetSymmetricSecurityKey(),
                ValidateIssuerSigningKey = true,
            };
        }
    }

    /// <summary>
    /// Класс настроек генерации токена
    /// </summary>
    public class JwtBearerTokenOptions
    {
        public const string ISSUER = "todo_project";
        public const string AUDIENCE = "todo_project_user";
        private const string KEY = "uIz4K1q3aG7eV9yS2wB5rP8wN3zQ6tY9";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
