using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SamStore.Costumer.Domain.Interfaces;
using SamStore.Costumer.Infrastructure.Contexts;
using SamStore.Costumer.Infrastructure.Repositories;
using SamStore.Core.CQRS.MediatR;
using System.Reflection;
using SamStore.Costumer.API.Services;

namespace SamStore.Costumer.API.Configurations       
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

            services.AddMediatR(AppDomain.CurrentDomain.Load("SamStore.Costumer.Application"));

            services.AddHostedService<RegisteredUserIntegrationEventHandler>();
        }
    }
}
