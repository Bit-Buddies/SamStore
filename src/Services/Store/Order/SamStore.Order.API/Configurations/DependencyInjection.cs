using MediatR;
using SamStore.MessageBus.Extensions;
using SamStore.Core.Extensions;

namespace SamStore.Order.API.Configurations
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(AppDomain.CurrentDomain.Load("SamStore.Order.Application"));
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"));
        }
    }
}
