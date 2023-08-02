using Microsoft.Extensions.Options;
using SamStore.BFF.Orders.Interfaces;
using SamStore.BFF.Orders.Models;
using SamStore.WebAPI.Core.Http;

namespace SamStore.BFF.Orders.Services
{
    public class ShoppingCartService : HttpClientService, IShoppingCartService
    {
        public ShoppingCartService(HttpClient httpClient, IOptions<AppServicesSettingsDTO> settings) : base(httpClient)
        {
            _httpClient.BaseAddress = new Uri(settings.Value.ShoppingCartBaseURL);
        }
    }
}
