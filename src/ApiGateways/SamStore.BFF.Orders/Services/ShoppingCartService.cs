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
        private IOptions<AppServicesSettingsDTO> _settings;

        public ShoppingCartService(HttpClient httpClient, IOptions<AppServicesSettingsDTO> settings) : base(httpClient) 
        {
            _settings = settings;
            _httpClient.BaseAddress = new Uri(_settings.Value.ShoppingCartBaseURL);
        } 

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

        public async Task<VoucherDTO> GetVoucherByKey(string key)
        {
            using (var httpClient = CreateTransientHttpClient(_settings.Value.OrderBaseURL))
            {
                var result = await EnsureSuccessStatusCode()
                    .GetAsync<VoucherDTO>($"Voucher/{key}", httpClient);

                return result;
            }
        }
    }
}
