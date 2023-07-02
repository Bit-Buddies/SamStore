using SamStore.Core.Domain;
using SamStore.Core.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Order.Domain.Vouchers
{
    public class Voucher : Entity, IAggregateRoot
    {
        public string Key { get; private set; }
        public decimal Discount { get; private set; } = 0;
        public decimal Percentual { get; private set; } = 0;
        public int Quantity { get; private set; }
        public int QuantityUsed { get; private set; } = 0;
        public bool Active { get; private set; } = true;

        public virtual ICollection<VoucherOrder> VoucherOrders { get; set; }
    }
}
