using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SamStore.Core.Infrastructure.Data;
using SamStore.Core.Infrastructure.Data.Helpers;
using SamStore.Order.Domain.Vouchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamStore.Core.Infrastructure.Data.Extensions;
using SamStore.Core.CQRS.MediatR;

namespace SamStore.Order.Infrastructure.Contexts
{
    public class OrderContext : DbContext, IUnitOfWork
    {
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<VoucherOrder> VouchersOrders { get; set; }

        private readonly IMediatorHandler _mediatorHandler;

        public OrderContext(DbContextOptions options, IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseDefaultTableConfiguration();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            if (!ChangeTracker.HasChanges())
                return true;

            ContextTrackerConfigurations.MapChanges(ChangeTracker);

            var success = (await SaveChangesAsync()) > 0;

            if (success)
                await _mediatorHandler.PublishEvents(this);

            return success;
        }
    }
}
