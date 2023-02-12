using SamStore.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.ShoppingCart.Domain.ShoppingCarts
{
    public class ShoppingCartItem : Entity
    {
        public Guid ProductId { get; private set; }
        public Guid ShoppingCartId { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public string Image { get; private set; }

        public ShoppingCartItem(Guid productId, Guid shoppingCartId, string name, int quantity, decimal price, string image)
        {
            ProductId = productId;
            ShoppingCartId = shoppingCartId;
            Name = name;
            Quantity = quantity;
            Price = price;
            Image = image;
        }
    }
}
