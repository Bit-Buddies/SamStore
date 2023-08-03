using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SamStore.Core.Domain;
using SamStore.Core.Infrastructure.Data;
using SamStore.Core.Infrastructure.Data.Extensions;
using SamStore.Core.Infrastructure.Data.Helpers;
using SamStore.ShoppingCart.Domain.ShoppingCarts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.ShoppingCart.Infrastructure.Contexts
{
    public class ShoppingCartContext : DbContext, IUnitOfWork
    {
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options) : base(options) 
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseDefaultTableConfiguration();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShoppingCartContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
        }

        public async Task<bool> Commit()
        {
            ChangeTracker.DetectChanges();

            if (!ChangeTracker.HasChanges())
                return true;

            ContextTrackerConfigurations.DetectChanges(ChangeTracker);

            try
            {
                var success = await SaveChangesAsync() > 0;

                return success;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
