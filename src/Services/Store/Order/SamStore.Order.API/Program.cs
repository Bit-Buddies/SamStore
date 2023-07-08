using SamStore.Order.API.Configurations;
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
            .WithOrigins("http://localhost", "http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
    );
});

var app = builder.Build();

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
