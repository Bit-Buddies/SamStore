using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SamStore.Catalogo.API.Domain.Products;
using SamStore.Core.Domain;
using SamStore.Core.Infrastructure.Data;
using SamStore.Core.Infrastructure.Data.Extensions;

namespace SamStore.Catalogo.API.Data.Contexts
{
    public class CatalogDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Product> Products { get; set; }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseDefaultTableConfiguration();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseDefaultContextConfiguration();

            base.OnConfiguring(optionsBuilder);
        }

        public async Task Commit()
        {
            if (!ChangeTracker.HasChanges())
                return;

            foreach (EntityEntry<Entity> entry in ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Detached: break;
                    case EntityState.Unchanged: break;
                    case EntityState.Deleted:
                        entry.Entity.Removed = true;
                        entry.Entity.AlteredAt = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.AlteredAt = DateTime.Now;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        entry.Entity.AlteredAt = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }
            
            await SaveChangesAsync();
        }
    }
}
