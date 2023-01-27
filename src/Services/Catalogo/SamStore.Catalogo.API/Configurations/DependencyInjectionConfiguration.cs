using Microsoft.EntityFrameworkCore;
using SamStore.Catalogo.API.Data.Contexts;
using SamStore.Catalogo.API.Data.Repositories;
using SamStore.Catalogo.API.Domain.Interfaces;
using System.Runtime.CompilerServices;

namespace SamStore.Catalogo.API.Configurations
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
