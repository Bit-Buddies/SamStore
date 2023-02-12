using SamStore.Core.Domain;
using SamStore.Core.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.ShoppingCart.Domain.ShoppingCarts
{
    public class ShoppingCart : Entity, IAggregateRoot
    {
        public Guid CostumerId { get; private set; }
        public decimal Total { get; private set; }
        public ICollection<ShoppingCartItem> Items { get; private set; } = new List<ShoppingCartItem>();

        protected ShoppingCart() { }
        public ShoppingCart(Guid costumerId)
        {
            CostumerId = costumerId;
        }
    }
}
