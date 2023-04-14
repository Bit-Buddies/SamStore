using SamStore.Core.Domain;
using System.Runtime.CompilerServices;

namespace SamStore.Catalog.API.Domain.Products
{
    public class ProductImage : Entity
    {
        public Guid ProductId { get; private set; }
        public string Name { get; private set; }
        public string Path { get; private set; }
        public int Order { get; private set; }
        public string Hash { get; private set; }
        public virtual Product Product { get; private set; }

        protected ProductImage() { }
        public ProductImage(string name, string path, int order)
        {
            Name = name;
            Path = path;
            Hash = GetHashString();
            Order = order;
        }

        public void ChangeOrder(int newOrder)
        {
            Order = newOrder;
        }

        public string GetHashString()
        {
            return HashCode.Combine(ProductId, Name, Path).ToString();
        }
    }
}
