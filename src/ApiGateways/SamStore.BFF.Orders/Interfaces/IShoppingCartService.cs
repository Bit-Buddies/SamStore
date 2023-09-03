using SamStore.BFF.Orders.Models;

namespace SamStore.BFF.Orders.Interfaces
{
    public interface IShoppingCartService
    {
        Task<ShoppingCartDTO> GetCustomerCartAsync();
        Task<bool> UpdateCustomerCartAsync(ShoppingCartDTO shoppingCart);
        Task<VoucherDTO> GetVoucherByKey(string key);
    }
}