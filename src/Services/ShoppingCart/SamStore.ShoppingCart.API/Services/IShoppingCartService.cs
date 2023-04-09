using SamStore.ShoppingCart.Domain.ShoppingCarts;

namespace SamStore.ShoppingCart.API.Services
{
    public interface IShoppingCartService
    {
        Task<Cart> GetCustomerCart();
        Task RemoveCartItem(Guid productId);
        Task AddCartItem(CartItem item);
        Task ClearCustomerCart();
    }
}