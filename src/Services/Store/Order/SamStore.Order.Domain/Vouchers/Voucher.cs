using SamStore.Core.Domain;
using SamStore.Core.Infrastructure.Data;
using SamStore.Order.Domain.Vouchers.Enums;
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
        public VoucherDiscountTypeEnum VoucherDiscountType { get; private set; }
        public VoucherTypeEnum VoucherType { get; private set; }    
        public decimal Discount { get; private set; }
        public int Quantity { get; private set; }
        public int QuantityUsed { get; private set; } = 0;
        public DateTime ExpireAt { get; private set; } = DateTime.MinValue;
        public bool IsActive { get; private set; } = true;

        public virtual ICollection<VoucherOrder> VoucherOrders { get; set; }

        protected Voucher() { }
        public Voucher(string key, decimal discount, VoucherDiscountTypeEnum voucherType, int quantity = 1, DateTime expireAt = default)
        {
            if (discount <= 0)
                throw new ArgumentException(nameof(discount));

            if (quantity <= 0)
                throw new ArgumentException(nameof(quantity));

            if (string.IsNullOrEmpty(key))
                throw new ArgumentException(nameof(key));

            Key = key;
            Discount = discount;
            Quantity = quantity;
            VoucherDiscountType = voucherType;
            ExpireAt = expireAt;
        }

        public void UseVoucher()
        {
            QuantityUsed += 1;

            switch (VoucherType)
            {
                case VoucherTypeEnum.Default:
                    if (QuantityUsed > Quantity)
                        throw new Exception("Voucher reached the limit of uses.");
                    break;
                case VoucherTypeEnum.Expire:
                    if (DateTime.Now.Date > ExpireAt.Date)
                        throw new Exception("Voucher already expired.");
                    break;
                default:
                    break;
            }
        }
    }
}
