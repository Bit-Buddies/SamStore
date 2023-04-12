using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SamStore.Costumer.Domain.Interfaces;
using SamStore.Costumer.Infrastructure.Contexts;
using SamStore.Costumer.Infrastructure.Repositories;
using SamStore.Core.CQRS.MediatR;
using System.Reflection;
using SamStore.Costumer.API.Services;
using SamStore.MessageBus.Extensions;

namespace SamStore.Costumer.API.Configurations       
{
    public static class ServicesConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddHostedService<RegisteredUserIntegrationEventHandler>();
        }
    }
}
