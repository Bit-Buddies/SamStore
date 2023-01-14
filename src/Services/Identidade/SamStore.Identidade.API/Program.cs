using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SamStore.Identidade.API.Data;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrWhiteSpace(connectionString))
    throw new ArgumentNullException("String de conexão não informada nas variáveis de ambiente. Aguardando 'DefaultConnection'");

builder.Services.AddDbContext<IdentidadeDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentidadeDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "SamStore Identity API",
        Description = "Essa API está sendo desenvolvida para prática e estudos em paralelo ao curso de ASP.NET Core Enterprise Applications do Desenvolvedor.IO",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact() { Name = "Samuel de Carvalho", Email = "samueldcarvalho99@gmail.com" },
        License = new Microsoft.OpenApi.Models.OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT")}
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
