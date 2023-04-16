using Microsoft.EntityFrameworkCore;
using SamStore.ShoppingCart.Application.Extensions;
using SamStore.ShoppingCart.Application.Models;
using SamStore.ShoppingCart.Domain.ShoppingCarts;
using SamStore.ShoppingCart.Infrastructure.Contexts;
using SamStore.WebAPI.Core.User;

namespace SamStore.ShoppingCart.API.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IContextUser _contextUser;
        private readonly ShoppingCartContext _context;

        public ShoppingCartService(IContextUser contextUser, ShoppingCartContext context)
        {
            _contextUser = contextUser;
            _context = context;
        }

        public async Task<ShoppingCartDTO> GetCustomerCart()
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.CostumerId == _contextUser.GetUserId());

            if (cart == null)
                cart = new Cart(_contextUser.GetUserId());

            return cart.ToDTO();
        }

        public async Task UpdateCustomerCart(ShoppingCartDTO cartDTO)
        {
            var cart = new Cart(_contextUser.GetUserId()) { Id = cartDTO.Id, };

            var existantCart = await _context.Carts
                .Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == cartDTO.Id);

            if (existantCart != null)
            {
                if(existantCart.Items.Any()){
                    _context.CartItems.RemoveRange(existantCart.Items);
                    existantCart.Clear();
                    _context.Carts.Update(existantCart);
                    await CommitChanges();
                }

                foreach (var item in cartDTO.Items)
                {
                    existantCart.AddItem(new CartItem(item.ProductId, item.CartId, item.Name, item.Quantity, item.Price, item.ImagePath!));
                }

                _context.Carts.Update(existantCart);
                _context.CartItems.AddRange(existantCart.Items);
            }
            else
            {
                foreach (var item in cartDTO.Items)
                    cart.AddItem(new CartItem(item.ProductId, item.CartId, item.Name, item.Quantity, item.Price, item.ImagePath!));

                _context.Carts.Add(cart);
            }

            await CommitChanges();
        }

        private async Task<bool> CommitChanges()
        {
            return await _context.Commit();
        }
    }
}
