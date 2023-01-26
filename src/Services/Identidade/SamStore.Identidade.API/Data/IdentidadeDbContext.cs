using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SamStore.Core.Infrastructure.Data.Extensions;

namespace SamStore.Identidade.API.Data
{
    public class IdentidadeDbContext : IdentityDbContext
    {
        public IdentidadeDbContext(DbContextOptions<IdentidadeDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseDefaultContextConfiguration();
        }
    }
}
