using Microsoft.EntityFrameworkCore;
using SamStore.Costumer.API.Configurations;
using SamStore.Costumer.Infrastructure.Contexts;
using SamStore.WebAPI.Core.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrWhiteSpace(connectionString))
    throw new ArgumentNullException(nameof(connectionString));

builder.Services.AddDbContext<CostumerDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddDIConfiguration(builder.Configuration);

builder.Services.AddMediatR(options => 
    options.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.Load("SamStore.Costumer.Application")));

builder.Services.AddMessageBusConfiguration(builder.Configuration);

builder.Services.AddSwaggerConfiguration("Api Customer");

builder.Services.AddCors(setup =>
{
    setup.AddPolicy("CorsPolicy", options =>
        options
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CostumerDbContext>();
    context.Database.Migrate();
}

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
