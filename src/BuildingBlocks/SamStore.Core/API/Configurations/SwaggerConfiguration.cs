﻿using Microsoft.Extensions.DependencyInjection;

namespace SamStore.Core.API.Configurations
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
            });
        }
    }
}
