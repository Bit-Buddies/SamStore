using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using SamStore.Cliente.Domain.Customers;
using SamStore.Core.CQRS.MediatR;
using SamStore.Core.Domain;
using SamStore.Core.Infrastructure.Data;
using SamStore.Core.Infrastructure.Data.Extensions;

namespace SamStore.Cliente.Infrastructure.Contexts
{
    public class CustomerDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options, IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

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

            var success = await SaveChangesAsync() > 0;

            if (success)
                await _mediatorHandler.PublishEvents(this);

            return success;
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
