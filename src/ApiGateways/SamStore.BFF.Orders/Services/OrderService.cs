using Microsoft.Extensions.Options;
using SamStore.BFF.Orders.Interfaces;
using SamStore.BFF.Orders.Models;
using SamStore.WebAPI.Core.Http;

namespace SamStore.BFF.Orders.Services
{
    public class OrderService : HttpClientService, IOrderService
    {
        public OrderService(HttpClient httpClient, IOptions<AppSettingsServices> settings) : base(httpClient, settings.Value.OrderBaseURL)
        { }

        public async Task<VoucherDTO> GetVoucherByKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return null;

            using HttpClient httpClient =
                CreateTransientHttpClient(_settings.Value.OrderBaseURL);

            var result = await EnsureSuccessStatusCode()
                .GetAsync<VoucherDTO>($"Voucher/{key}", httpClient);

            return result;
        }
    }
}
