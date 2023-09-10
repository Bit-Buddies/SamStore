using SamStore.Core.Domain;
using SamStore.Core.Domain.ValueObjects;
using SamStore.Core.Infrastructure.Data;
using SamStore.ShoppingCart.Domain.Vouchers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.ShoppingCart.Domain.Vouchers
{
    public class Voucher : IValueObject
    {
        public string Key { get; set; }
        public decimal Discount { get; set; }
        public VoucherDiscountTypeEnum VoucherDiscountType { get; set; }
        public int Quantity { get; set; }
    }
}
