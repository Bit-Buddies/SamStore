namespace SamStore.BFF.Orders.Models
{
    public class ShoppingCartDTO
    {
        public Guid Id { get; set; }
        public Guid CostumerId { get; set; }
        public decimal Total { get; set; }
        public List<ShoppingCartItemDTO> Items { get; set; }
    }
}
