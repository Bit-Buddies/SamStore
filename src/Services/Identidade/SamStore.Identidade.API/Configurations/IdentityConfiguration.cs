using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SamStore.Identidade.API.Data;
using SamStore.WebAPI.Core.Identity;
using System.Text;

namespace SamStore.Identidade.API.Configurations
{
    public static class IdentityConfiguration
    {
        public static void AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<IdentidadeDbContext>()
                .AddDefaultTokenProviders();

            services.AddJwtConfiguration(configuration);
        }
    }
}
