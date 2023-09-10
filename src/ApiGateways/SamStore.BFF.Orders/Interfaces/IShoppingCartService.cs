using SamStore.BFF.Orders.Models;

namespace SamStore.BFF.Orders.Interfaces
{
    public interface IShoppingCartService
    {
        Task ApplyVoucher(VoucherDTO voucher);
        Task<ShoppingCartDTO> GetCustomerCartAsync();
        Task<bool> UpdateCustomerCartAsync(ShoppingCartDTO shoppingCart);
    }
}