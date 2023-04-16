using SamStore.ShoppingCart.Application.Models;
using SamStore.ShoppingCart.Domain.ShoppingCarts;

namespace SamStore.ShoppingCart.API.Services
{
    public interface IShoppingCartService
    {
        Task<ShoppingCartDTO> GetCustomerCart();
        Task UpdateCustomerCart(ShoppingCartDTO cart);
    }
}