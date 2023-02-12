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

        public bool ItemAlreadyExists(CartItem item)
        {
            return Items.Any(i => i.ProductId == item.ProductId);
        }

        public CartItem GetItemByProductId(Guid productId)
        {
            return Items.FirstOrDefault(i => i.ProductId == productId);
        }

        public void AddItem(CartItem item)
        {
            if (!item.IsValid())
                return;

            item.LinkCart(Id);
         
            if(ItemAlreadyExists(item)) 
            {
                CartItem oldItem = GetItemByProductId(item.ProductId);
                oldItem.AddQuantity(item.Quantity);

                item = oldItem;
                Items.Remove(oldItem);
            }

            Items.Add(item);

            Total = Items.Sum(i => i.CalcPrice());
        }
    }
}
