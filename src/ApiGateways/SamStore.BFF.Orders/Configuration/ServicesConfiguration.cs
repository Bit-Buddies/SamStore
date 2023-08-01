using SamStore.WebAPI.Core.User;

namespace SamStore.BFF.Orders.Configuration
{
    public static class ServicesConfiguration
    {
        public static void AddDiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IHttpContextHandler, HttpContextHandler>();
        }
    }
}
