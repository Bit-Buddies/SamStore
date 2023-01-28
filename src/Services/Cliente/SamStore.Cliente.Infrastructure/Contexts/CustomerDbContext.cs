using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using SamStore.Cliente.Domain.Customers;
using SamStore.Core.Domain;
using SamStore.Core.Infrastructure.Data;
using SamStore.Core.Infrastructure.Data.Extensions;

namespace SamStore.Cliente.Infrastructure.Contexts
{
    public class CustomerDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }

        public async Task<bool> Commit()
        {
            if (!ChangeTracker.HasChanges())
                return true;

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

            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (IMutableForeignKey? relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            modelBuilder.UseDefaultTableConfiguration();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseDefaultContextConfiguration();
        }
    }
}
