using MediatR;
using SamStore.MessageBus.Extensions;
using SamStore.Core.Extensions;
using SamStore.Order.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using SamStore.Core.CQRS.MediatR;

namespace SamStore.Order.API.Configurations
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if(string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            services.AddDbContext<OrderContext>(options => options
                .UseSnakeCaseNamingConvention()
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddMediatR(AppDomain.CurrentDomain.Load("SamStore.Order.Application"));
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"));
        }
    }
}
