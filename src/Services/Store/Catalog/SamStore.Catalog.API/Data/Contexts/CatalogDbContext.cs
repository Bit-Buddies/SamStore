using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SamStore.Catalog.API.Domain.Products;
using SamStore.Core.Domain;
using SamStore.Core.Infrastructure.Data;
using SamStore.Core.Infrastructure.Data.Extensions;
using SamStore.Core.Infrastructure.Data.Helpers;

namespace SamStore.Catalog.API.Data.Contexts
{
    public class CatalogDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Product> Products { get; set; }


        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) { }

        public async Task<bool> Commit()
        {
            if (!ChangeTracker.HasChanges())
                return true;

            ContextTrackerConfigurations.MapChanges(ChangeTracker);

            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseDefaultTableConfiguration();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseDefaultContextConfiguration();
        }
    }
}
