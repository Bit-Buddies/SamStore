namespace SamStore.BFF.Orders.Models
{
    public class VoucherDTO
    {
        public string Key { get; set; }
        public int VoucherDiscountType { get; set; }
        public int VoucherType { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
    }
}
