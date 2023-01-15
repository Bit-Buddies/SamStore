using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SamStore.Identidade.API.Data
{
    public class IdentidadeDbContext : IdentityDbContext
    {
        public IdentidadeDbContext(DbContextOptions<IdentidadeDbContext> options) : base(options) { }
    }
}
