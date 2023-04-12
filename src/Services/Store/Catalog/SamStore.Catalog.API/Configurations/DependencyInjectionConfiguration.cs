using Microsoft.EntityFrameworkCore;
using SamStore.Catalog.API.Data.Contexts;
using SamStore.Catalog.API.Data.Repositories;
using SamStore.Catalog.API.Domain.Interfaces;
using System.Runtime.CompilerServices;

namespace SamStore.Catalog.API.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            services.AddDbContext<CatalogDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
