using SamStore.ShoppingCart.Application.Models;
using SamStore.ShoppingCart.Domain.ShoppingCarts;

namespace SamStore.ShoppingCart.API.Services
{
    public interface IShoppingCartService
    {
        Task ApplyVoucher(VoucherDTO voucher);
        Task<ShoppingCartDTO> GetCustomerCart();
        Task UpdateCustomerCart(ShoppingCartDTO cart);
    }
}