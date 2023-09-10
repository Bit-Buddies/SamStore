using SamStore.ShoppingCart.Domain.Vouchers.Enums;

namespace SamStore.ShoppingCart.Application.Models
{
    public record VoucherDTO
    {
        public string Key { get; set; }
        public decimal Discount { get; set; }
        public VoucherDiscountTypeEnum VoucherDiscountType { get; set; }
        public int Quantity { get; set; }
    }
}
