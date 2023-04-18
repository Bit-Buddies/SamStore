using SamStore.BFF.Orders.Configuration;
using SamStore.WebAPI.Core.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration(builder.Configuration);
builder.Services.AddDiConfiguration(builder.Configuration);
builder.Services.AddSwaggerConfiguration("BFF Orders");
builder.Services.AddMessageBus(builder.Configuration);

var app = builder.Build();

app.UseApiConfiguration(builder.Configuration);

