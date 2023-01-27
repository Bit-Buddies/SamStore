using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace SamStore.WebAPI.Core.API.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services, string apiName)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = $"{apiName.Trim()} - SamStore",
                    Description = "Essa API está sendo desenvolvida para prática e estudos em paralelo ao curso de ASP.NET Core Enterprise Applications do Desenvolvedor.IO",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact() { Name = "Samuel de Carvalho", Email = "samueldcarvalho99@gmail.com" },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insert your JWT following the scheme: 'Bearer {JWT}'",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
        }
    }
}
