using Microsoft.Extensions.DependencyInjection;
using SamStore.Core.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.MessageBus.Extensions
{
    public static class MessageBusExtensions
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection services, string connection)
        {
            if(connection.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(connection));

            services.AddSingleton<IMessageBus>(new MessageBus(connection));

            return services;
        }
    }
}
