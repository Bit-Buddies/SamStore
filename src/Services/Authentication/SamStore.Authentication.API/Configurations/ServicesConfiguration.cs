using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SamStore.Authentication.API.Data;
using SamStore.Core.Infrastructure.Data;

namespace SamStore.Authentication.API.Configurations
{
    public static class ServicesConfiguration
    {
        public static void AddServicesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException("String de conexão não informada nas variáveis de ambiente. Aguardando 'DefaultConnection'");

            services.AddDbContext<IdentidadeDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        }
    }
}
