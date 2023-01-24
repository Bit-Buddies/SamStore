using SamStore.Core.Domain;

namespace SamStore.Catalogo.API.Domain.Products
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Value { get; private set; }
        public string Image { get; private set; }
        public int Quantity { get; private set; }
    }
}
