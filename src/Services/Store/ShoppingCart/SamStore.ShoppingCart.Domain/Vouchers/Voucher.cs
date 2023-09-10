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
        public bool Used { get; private set; } = false;
        public string? Key { get; private set; }
        public decimal? Discount { get; private set; }
        public VoucherDiscountTypeEnum? DiscountType { get; private set; }

        public Voucher(string key, decimal discount, VoucherDiscountTypeEnum discountType)
        {
            Key = key;
            Discount = discount;
            DiscountType = discountType;
            Used = true;

            IsValid();
        }

        private void IsValid()
        {
            if (string.IsNullOrWhiteSpace(Key))
                throw new ArgumentException(nameof(Key));

            if (Discount == null || Discount <= 0)
                throw new ArgumentException(nameof(Discount));

            if (DiscountType == null)
                throw new ArgumentException(nameof(DiscountType));
        }
    }
}
