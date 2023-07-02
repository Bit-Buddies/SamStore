using SamStore.Core.Domain;
using SamStore.Core.Infrastructure.Data;
using SamStore.Order.Domain.Vouchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Order.Domain.Orders
{
    public class Order : Entity, IAggregateRoot
    {
        public virtual ICollection<VoucherOrder> VoucherOrder { get; set; }
    }
}
