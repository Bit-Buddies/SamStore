using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.WebAPI.Core.Identity
{
    public static class JsonWebTokenConfiguration
    {
        public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var identitySettingsSection = configuration.GetSection("IdentitySettings");

            services.Configure<IdentitySettingsDTO>(identitySettingsSection);

            IdentitySettingsDTO identitySettings = identitySettingsSection.Get<IdentitySettingsDTO>();

            if (identitySettings == null)
                throw new NullReferenceException("IdentitySettings cannot be empty");

            var key = Encoding.ASCII.GetBytes(identitySettings.Secret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = identitySettings.Audience,
                    ValidIssuer = identitySettings.Issuer
                };
            });
        }

    }
}
