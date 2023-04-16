using SamStore.ShoppingCart.Application.Models;
using SamStore.ShoppingCart.Domain.ShoppingCarts;

namespace SamStore.ShoppingCart.API.Services
{
    public interface IShoppingCartService
    {
        Task<ShoppingCartDTO> GetCustomerCart();
        Task UpdateCustomerCart(ShoppingCartDTO cart);
        Task RemoveCartItem(Guid productId);
        Task AddCartItem(ShoppingCartItemDTO item);
        Task ClearCustomerCart();
    }
}