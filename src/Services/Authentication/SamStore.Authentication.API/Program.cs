using SamStore.Authentication.API.Configurations;
using SamStore.Costumer.API.Configurations;
using SamStore.WebAPI.Core.API.Configurations;
using SamStore.WebAPI.Core.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", config =>
    {
        config.WithOrigins("http://localhost", "http://localhost:4200");
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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
