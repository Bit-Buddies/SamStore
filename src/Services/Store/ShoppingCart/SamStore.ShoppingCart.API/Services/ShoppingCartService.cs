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

        public async Task AddCartItem(ShoppingCartItemDTO item)
        {
            var newItem = new CartItem(item.ProductId, item.CartId, item.Name, item.Quantity, item.Price, item.ImagePath);

            await GetCustomerCartAddingItem(newItem);
        }

        public async Task RemoveCartItem(Guid productId)
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.CostumerId == _contextUser.GetUserId());

            cart.RemoveItem(productId);

            await CommitChanges();
        }

        public async Task ClearCustomerCart()
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.CostumerId == _contextUser.GetUserId());

            cart.Clear();

            await CommitChanges();
        }

        private async Task<Cart> GetCustomerCartAddingItem(CartItem item)
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.CostumerId == _contextUser.GetUserId());

            if (cart == null)
                cart = new Cart(_contextUser.GetUserId());

            if (!_context.Carts.Any(c => c.Id == cart.Id))
            {
                _context.Carts.Add(cart);
                await CommitChanges();
            }

            cart.AddItem(item);

            _context.Update(cart);

            await CommitChanges();

            return cart;
        }

        private async Task<bool> CommitChanges()
        {
            if (!_context.ChangeTracker.HasChanges())
                return true;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task UpdateCustomerCart(ShoppingCartDTO cartDTO)
        {
            var cart = new Cart(_contextUser.GetUserId())
            {
                Id = cartDTO.Id,
            };

            foreach (var item in cartDTO.Items)
                cart.AddItem(new CartItem(item.ProductId, item.CartId, item.Name, item.Quantity, item.Price, item.ImagePath));

            bool alreadyExists = await _context.Carts.AnyAsync(x => x.Id == cartDTO.Id);

            if (alreadyExists)
            {
                _context.Carts.Update(cart); 
            }
            else
            {
                _context.Carts.Add(cart);
            }

            await _context.SaveChangesAsync();
        }
    }
}
