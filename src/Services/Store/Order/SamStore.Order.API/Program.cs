using Microsoft.EntityFrameworkCore;
using SamStore.Order.API.Configurations;
using SamStore.Order.Infrastructure.Contexts;
using SamStore.WebAPI.Core.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDependencyInjection(builder.Configuration);
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerConfiguration("Api Order");
builder.Services.ConfigureObjectMapping(builder.Configuration);

builder.Services.AddCors(setup =>
{
    setup.AddPolicy("CorsPolicy", options =>
        options
            .SetIsOriginAllowed(_ => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
    );
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<OrderContext>();
    context.Database.Migrate();
} 

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
