using Microsoft.Extensions.Options;
using SamStore.BFF.Orders.Interfaces;
using SamStore.BFF.Orders.Models;
using SamStore.WebAPI.Core.API.Models;
using SamStore.WebAPI.Core.Http;
using System.Runtime;

namespace SamStore.BFF.Orders.Services
{
    public class ShoppingCartService : HttpClientService, IShoppingCartService
    {
        public ShoppingCartService(HttpClient httpClient, IOptions<AppSettingsServices> settings) : base(httpClient, settings.Value.ShoppingCartBaseURL) 
        { }

        public async Task<ShoppingCartDTO> GetCustomerCartAsync()
        {
            ShoppingCartDTO result = await EnsureSuccessStatusCode()
                .GetAsync<ShoppingCartDTO>("ShoppingCart");

            return result;
        }

        public async Task<bool> UpdateCustomerCartAsync(ShoppingCartDTO shoppingCart)
        {
            bool result = await EnsureSuccessStatusCode()
                .PutAsync("ShoppingCart", shoppingCart);

            return result;
        }

        public async Task ApplyVoucher(VoucherDTO voucher)
        {
            await EnsureSuccessStatusCode()
                .PostAsync("ShoppingCart/voucher", voucher);
        }
    }
}
