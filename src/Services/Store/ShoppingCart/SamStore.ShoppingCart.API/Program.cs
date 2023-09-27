using Microsoft.EntityFrameworkCore;
using SamStore.ShoppingCart.API.Configurations;
using SamStore.ShoppingCart.Infrastructure.Contexts;
using SamStore.WebAPI.Core.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceConfiguration(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ShoppingCartContext>();
    context.Database.Migrate();
}

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
