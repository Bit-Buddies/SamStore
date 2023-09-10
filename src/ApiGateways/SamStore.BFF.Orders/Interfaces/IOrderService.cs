using SamStore.BFF.Orders.Models;

namespace SamStore.BFF.Orders.Interfaces
{
    public interface IOrderService
    {
        Task<VoucherDTO> GetVoucherByKey(string key);
    }
}