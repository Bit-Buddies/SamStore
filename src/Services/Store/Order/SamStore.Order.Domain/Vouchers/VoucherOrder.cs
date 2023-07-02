using SamStore.Core.Domain;
using SamStore.Order.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Order.Domain.Vouchers
{
    public class VoucherOrder : Entity
    {
        public Guid VoucherId { get; set; }
        public virtual Voucher Voucher { get; set; }
        public Guid OrderId { get; set; }
        public virtual Orders.Order Order { get; set; }

        protected VoucherOrder() { }
    }
}
