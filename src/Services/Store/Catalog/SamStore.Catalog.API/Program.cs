using SamStore.Catalog.API.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using SamStore.Catalog.API.Domain.Interfaces;
using SamStore.Catalog.API.Data.Repositories;
using SamStore.WebAPI.Core.API.Configurations;
using SamStore.WebAPI.Core.Identity;
using SamStore.Catalog.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencyInjectionConfiguration(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration("Api Catalog");
builder.Services.AddJwtConfiguration(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", config =>
    {
        config.AllowAnyOrigin();
        config.AllowAnyMethod();
        config.AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CatalogDbContext>();
    context.Database.Migrate();
}

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();