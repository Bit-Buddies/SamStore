using SamStore.WebAPI.Core.Context;

namespace SamStore.BFF.Orders.Configuration
{
    public static class ServicesConfiguration
    {
        public static void AddDiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IHttpContextHandler, HttpContextHandler>();
        }
    }
}
