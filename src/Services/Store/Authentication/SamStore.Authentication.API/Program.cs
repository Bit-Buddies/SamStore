using Microsoft.EntityFrameworkCore;
using SamStore.Authentication.API.Configurations;
using SamStore.Authentication.API.Data;
using SamStore.Costumer.API.Configurations;
using SamStore.WebAPI.Core.API.Configurations;
using SamStore.WebAPI.Core.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", config =>
    {
        config.AllowAnyOrigin();
        config.AllowAnyMethod();
        config.AllowAnyHeader();
    });
});

builder.Services.AddIdentityConfiguration(builder.Configuration);

builder.Services.AddServicesConfiguration(builder.Configuration);

builder.Services.AddMessageBusConfiguration(builder.Configuration);

builder.Services.AddSwaggerConfiguration("Api Identity");

builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<IdentidadeDbContext>();
    context.Database.Migrate();
}

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
