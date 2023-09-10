using Microsoft.Extensions.Options;
using SamStore.BFF.Orders.Interfaces;
using SamStore.BFF.Orders.Models;
using SamStore.WebAPI.Core.Http;

namespace SamStore.BFF.Orders.Services
{
    public class OrderService : HttpClientService, IOrderService
    {
        private readonly IOptions<AppSettingsServices> _settings;

        public OrderService(HttpClient httpClient, IOptions<AppSettingsServices> settings) : base(httpClient)
        {
            _settings = settings;
        }

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

        protected override void Setup()
        {
            _httpClient.BaseAddress = new Uri(_settings.Value.OrderBaseURL);
        }
    }
}
