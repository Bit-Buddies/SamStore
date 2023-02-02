using Microsoft.EntityFrameworkCore;
using SamStore.Core.Domain.Utils;
using SamStore.ShoppingCart.Infrastructure.Contexts;
using SamStore.WebAPI.Core.API.Configurations;
using SamStore.WebAPI.Core.Identity;

namespace SamStore.ShoppingCart.API.Configurations
{
    public static class ServicesConfiguration
    {
        public static void AddDIConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            if (connectionString.IsNullOrWhiteSpace())
                throw new NullReferenceException("DefaultConnection cannot be empty");

            services.AddDbContext<ShoppingCartDbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });   
        }

        public static void AddServiceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            
            services.AddEndpointsApiExplorer();

            services.AddDIConfigurations(configuration);

            services.AddSwaggerConfiguration("Api ShoppingCart");

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", config =>
                {
                    config.WithOrigins("http://localhost", "http://localhost:4200");
                    config.AllowAnyMethod();
                    config.AllowAnyHeader();
                });
            });

            services.AddJwtConfiguration(configuration);
        }
    }
}
