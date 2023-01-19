using SamStore.Identidade.API.Configurations;

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

builder.Services.AddSwaggerConfiguration();

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

app.MapControllers();

app.Run();
