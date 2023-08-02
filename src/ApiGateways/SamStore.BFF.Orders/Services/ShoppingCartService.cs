using Microsoft.Extensions.Options;
using SamStore.BFF.Orders.Interfaces;
using SamStore.BFF.Orders.Models;
using SamStore.WebAPI.Core.API.Models;
using SamStore.WebAPI.Core.Http;

namespace SamStore.BFF.Orders.Services
{
    public class ShoppingCartService : HttpClientService, IShoppingCartService
    {
        public ShoppingCartService(HttpClient httpClient, IOptions<AppServicesSettingsDTO> settings)
            : base(httpClient) => _httpClient.BaseAddress = new Uri(settings.Value.ShoppingCartBaseURL);

        public async Task<ShoppingCartDTO> GetCustomerCartAsync()
        {
            ShoppingCartDTO result = await GetAsync<ShoppingCartDTO>("ShoppingCart");

            return result;
        }

        public async Task<bool> UpdateCustomerCartAsync(ShoppingCartDTO shoppingCart)
        {
            bool result = await PutAsync("/ShoppingCart", shoppingCart);

            return result;
        }
    }
}
