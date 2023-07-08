using MediatR;
using SamStore.MessageBus.Extensions;
using SamStore.Core.Extensions;
using SamStore.Order.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using SamStore.Core.CQRS.MediatR;
using SamStore.Order.Domain.Interfaces;
using SamStore.Order.Infrastructure.Repositories;
using SamStore.Order.Application.Interfaces;
using SamStore.Order.Application.Queries;

namespace SamStore.Order.API.Configurations
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IVoucherRepository, VoucherRepository>();
            services.AddScoped<IVoucherQueries, VoucherQueries>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if(string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            services.AddDbContext<OrderContext>(options => options
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .UseSnakeCaseNamingConvention());

            services.AddMediatR(AppDomain.CurrentDomain.Load("SamStore.Order.Application"));
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"));
        }
    }
}
