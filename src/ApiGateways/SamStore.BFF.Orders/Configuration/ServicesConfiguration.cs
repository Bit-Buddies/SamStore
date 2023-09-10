using SamStore.BFF.Orders.Interfaces;
using SamStore.BFF.Orders.Middlewares;
using SamStore.BFF.Orders.Models;
using SamStore.BFF.Orders.Services;
using SamStore.Core.Domain.Utils;
using SamStore.WebAPI.Core.Context;
using Polly;
using SamStore.Core.Extensions;

namespace SamStore.BFF.Orders.Configuration
{
    public static class ServicesConfiguration
    {
        public static void AddDiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            configuration.ValidateBaseUrls();

            services.Configure<AppSettingsServices>(configuration.GetSection("ApiBaseUrls"));

            services.AddHttpContextAccessor();
            services.AddScoped<IHttpContextHandler, HttpContextHandler>();

            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IShoppingCartService, ShoppingCartService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IOrderService, OrderService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
        }

        private static void ValidateBaseUrls(this IConfiguration configuration)
        {
            var settings = configuration.GetSection("ApiBaseUrls").Get<AppSettingsServices>();

            foreach (var property in settings.GetType().GetProperties())
            {
                var value = property.GetValue(settings);

                if (string.IsNullOrWhiteSpace(value?.ToString() ?? ""))
                    throw new ArgumentNullException(property.Name);

                if (!Uri.TryCreate(value.ToString(), UriKind.Absolute, out Uri _))
                    throw new InvalidCastException("Invalid baseURL def: " + property.Name);
            }
        }
    }
}
