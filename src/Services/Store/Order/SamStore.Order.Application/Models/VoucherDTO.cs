using SamStore.Order.Domain.Vouchers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Order.Application.Models
{
    public class VoucherDTO
    {
        public string Key { get; set; }
        public VoucherDiscountTypeEnum VoucherDiscountType { get; set; }
        public VoucherTypeEnum VoucherType { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
    }
}
