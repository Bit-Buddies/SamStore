using SamStore.BFF.Orders.Interfaces;
using SamStore.BFF.Orders.Models;
using SamStore.BFF.Orders.Services;
using SamStore.Core.Domain.Utils;
using SamStore.WebAPI.Core.Context;

namespace SamStore.BFF.Orders.Configuration
{
    public static class ServicesConfiguration
    {
        public static void AddDiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            ValidateBaseUrls(configuration);

            services.Configure<AppServicesSettingsDTO>(configuration.GetSection("ApiBaseUrls"));

            services.AddHttpClient();
            services.AddHttpContextAccessor();
            services.AddScoped<IHttpContextHandler, HttpContextHandler>();

            services.AddScoped<IShoppingCartService, ShoppingCartService>();
        }

        private static void ValidateBaseUrls(IConfiguration configuration)
        {
            var settings = configuration.GetSection("ApiBaseUrls").Get<AppServicesSettingsDTO>();

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
