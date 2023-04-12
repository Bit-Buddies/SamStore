using Microsoft.EntityFrameworkCore;
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

        public async Task<Cart> GetCustomerCart()
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.CostumerId == _contextUser.GetUserId());

            return cart ?? new Cart(_contextUser.GetUserId());
        }

        public async Task AddCartItem(CartItem item)
        {
            await GetCustomerCartAddingItem(item);
        }

        public async Task RemoveCartItem(Guid productId)
        {
            var cart = await GetCustomerCart();

            cart.RemoveItem(productId);

            await CommitChanges();
        }

        public async Task ClearCustomerCart()
        {
            var cart = await GetCustomerCart();
            cart.Clear();

            await CommitChanges();
        }

        private async Task<Cart> GetCustomerCartAddingItem(CartItem item)
        {
            var cart = await GetCustomerCart();

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

    }
}
