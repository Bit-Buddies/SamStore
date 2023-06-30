namespace SamStore.BFF.Orders.Models
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }
        public int QuantityStock { get; set; }
    }
}
