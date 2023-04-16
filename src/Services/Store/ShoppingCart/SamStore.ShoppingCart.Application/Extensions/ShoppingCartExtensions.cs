using SamStore.ShoppingCart.Application.Models;
using SamStore.ShoppingCart.Domain.ShoppingCarts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.ShoppingCart.Application.Extensions
{
    public static class ShoppingCartExtensions
    {
        public static ShoppingCartDTO ToDTO(this Cart cart) =>
            new ShoppingCartDTO
            {
                CostumerId = cart.CostumerId,
                Id = cart.Id,
                Items = cart.Items.Select<CartItem, ShoppingCartItemDTO>(x => x.ToDTO()).ToList(),
            };

        public static ShoppingCartItemDTO ToDTO(this CartItem item) =>
            new ShoppingCartItemDTO
            {
                Id = item.Id,
                CartId = item.CartId,
                ImagePath = item.Image,
                Name = item.Name,
                Price = item.Price,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
            };
    }
}
