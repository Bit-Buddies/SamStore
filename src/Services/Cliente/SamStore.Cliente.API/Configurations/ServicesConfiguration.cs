﻿using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SamStore.Cliente.Infrastructure.Contexts;
using SamStore.Core.CQRS.MediatR;
using System.Reflection;

namespace SamStore.Cliente.API.Configurations       
{
    public static class ServicesConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            services.AddDbContext<ConsumerDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddMediatR(AppDomain.CurrentDomain.Load("SamStore.Cliente.Application"));
        }
    }
}
