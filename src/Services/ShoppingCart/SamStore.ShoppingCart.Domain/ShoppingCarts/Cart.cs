using SamStore.Core.Domain;
using SamStore.Core.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.ShoppingCart.Domain.ShoppingCarts
{
    public class Cart : Entity, IAggregateRoot
    {
        public Guid CostumerId { get; private set; }
        public decimal Total { get; private set; }
        public ICollection<CartItem> Items { get; private set; } = new List<CartItem>();

        public Cart() { }
        public Cart(Guid costumerId)
        {
            CostumerId = costumerId;
        }

        internal void AddItem(CartItem item)
        {
            //validate


        }
    }
}
