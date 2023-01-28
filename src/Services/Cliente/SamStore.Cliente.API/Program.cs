using SamStore.Cliente.API.Configurations;
using SamStore.WebAPI.Core.API.Configurations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDIConfiguration(builder.Configuration);

builder.Services.AddSwaggerConfiguration("API de Cliente");

builder.Services.AddCors(setup =>
{
    setup.AddPolicy("CorsPolicy", options =>
        options
            .WithOrigins("http://localhost", "http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
