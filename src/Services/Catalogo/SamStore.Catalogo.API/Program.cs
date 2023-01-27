using SamStore.Catalogo.API.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using SamStore.Catalogo.API.Domain.Interfaces;
using SamStore.Catalogo.API.Data.Repositories;
using SamStore.WebAPI.Core.API.Configurations;
using SamStore.WebAPI.Core.Identity;
using SamStore.Catalogo.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencyInjectionConfiguration(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration("API de Catálogo");
builder.Services.AddJwtConfiguration(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options => options
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
