using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SamStore.Identidade.API.Data;
using SamStore.Identidade.API.Extensions;
using System.Text;

namespace SamStore.Identidade.API.Configurations
{
    public static class IdentityConfiguration
    {
        public static void AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentidadeDbContext>()
                .AddDefaultTokenProviders();

            var identitySettingsSection = configuration.GetSection("IdentitySettings");
            services.Configure<IdentitySettings>(identitySettingsSection);

            IdentitySettings identitySettings = identitySettingsSection.Get<IdentitySettings>();
            var key = Encoding.ASCII.GetBytes(identitySettings.Secret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
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
