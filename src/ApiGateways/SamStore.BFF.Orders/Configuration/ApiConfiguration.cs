using SamStore.WebAPI.Core.API.Middlewares;

namespace SamStore.BFF.Orders.Configuration
{
    public static class ApiConfiguration
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.AddCors(options => 
                options.AddPolicy("CorsPolicy", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()));
        }

        public static void UseApiConfiguration(this WebApplication app, IConfiguration configuration)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
