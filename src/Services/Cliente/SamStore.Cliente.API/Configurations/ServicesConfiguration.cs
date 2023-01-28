using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SamStore.Cliente.Domain.Interfaces;
using SamStore.Cliente.Infrastructure.Contexts;
using SamStore.Cliente.Infrastructure.Repositories;
using SamStore.Core.CQRS.MediatR;
using System.Reflection;

namespace SamStore.Cliente.API.Configurations       
{
    public static class ServicesConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            services.AddDbContext<CustomerDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddMediatR(AppDomain.CurrentDomain.Load("SamStore.Cliente.Application"));
        }
    }
}
