using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using SamStore.Costumer.Domain.Customers;
using SamStore.Core.CQRS.MediatR;
using SamStore.Core.Domain;
using SamStore.Core.Infrastructure.Data;
using SamStore.Core.Infrastructure.Data.Extensions;
using SamStore.Core.Infrastructure.Data.Helpers;

namespace SamStore.Costumer.Infrastructure.Contexts
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
            try
            {
                if (!ChangeTracker.HasChanges())
                    return true;

                ContextTrackerConfigurations.MapChanges(ChangeTracker);

                var success = await SaveChangesAsync() > 0;

                if (success)
                    await _mediatorHandler.PublishEvents(this);

                return success;
            }
            catch (Exception ex)
            {

                throw;
            } 
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
