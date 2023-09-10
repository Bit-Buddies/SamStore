using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SamStore.WebAPI.Core.Http
{
    public abstract class HttpClientService
    {
        protected HttpClient _httpClient;
        private bool _ensureSuccessStatusCode = false;

        public HttpClientService(HttpClient httpClient, string? baseUrl = null)
        {
            _httpClient = httpClient;

            if(baseUrl is not null)
                _httpClient.BaseAddress = new Uri(baseUrl);
        }

        public async Task<T> GetAsync<T>(string uri, HttpClient? httpClient = null)
        {
            httpClient ??= _httpClient;

            httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));


            using (HttpResponseMessage response = await httpClient.GetAsync(uri))
            {
                if (_ensureSuccessStatusCode)
                    response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(responseBody);
            }
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest dataRequest, HttpClient? httpClient = null)
        {
            httpClient ??= _httpClient;

            httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));


            StringContent content = CreateStringContent(dataRequest);

            using (HttpResponseMessage response = await httpClient.PostAsync(uri, content))
            {
                if (_ensureSuccessStatusCode)
                    response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TResponse>(responseBody);
            }
        }

        public async Task<bool> PostAsync<TRequest>(string uri, TRequest dataRequest, HttpClient? httpClient = null)
        {
            httpClient ??= _httpClient;

            httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            StringContent content = CreateStringContent(dataRequest);

            using HttpResponseMessage response = await httpClient.PostAsync(uri, content);

            if (_ensureSuccessStatusCode)
                response.EnsureSuccessStatusCode();

            return response.IsSuccessStatusCode;
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(string uri, TRequest dataRequest, HttpClient? httpClient = null)
        {
            httpClient ??= _httpClient;

            httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            StringContent content = CreateStringContent(dataRequest);

            using (HttpResponseMessage response = await httpClient.PutAsync(uri, content))
            {
                if (_ensureSuccessStatusCode)
                    response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TResponse>(responseBody);
            }
        }

        public async Task<bool> PutAsync<TRequest>(string uri, TRequest dataRequest, HttpClient? httpClient = null)
        {
            httpClient ??= _httpClient;

            httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            StringContent content = CreateStringContent(dataRequest);

            using HttpResponseMessage response = await httpClient.PutAsync(uri, content);

            if (_ensureSuccessStatusCode)
                response.EnsureSuccessStatusCode();

            return response.IsSuccessStatusCode;
        }

        public async Task<TResponse> PatchAsync<TRequest, TResponse>(string uri, TRequest dataRequest, HttpClient? httpClient = null)
        {
            httpClient ??= _httpClient;

            httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            StringContent content = CreateStringContent(dataRequest);

            using (HttpResponseMessage response = await httpClient.PatchAsync(uri, content))
            {
                if (_ensureSuccessStatusCode)
                    response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TResponse>(responseBody);
            }
        }

        public async Task<bool> PatchAsync<TRequest>(string uri, TRequest dataRequest, HttpClient? httpClient = null)
        {
            httpClient ??= _httpClient;

            httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            StringContent content = CreateStringContent(dataRequest);

            using HttpResponseMessage response = await httpClient.PatchAsync(uri, content);

            if (_ensureSuccessStatusCode)
                response.EnsureSuccessStatusCode();

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync<TRequest>(string uri, HttpClient? httpClient = null)
        {
            httpClient ??= _httpClient;

            httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using HttpResponseMessage response = await httpClient.DeleteAsync(uri);

            if (_ensureSuccessStatusCode)
                response.EnsureSuccessStatusCode();

            return response.IsSuccessStatusCode;
        }

        public HttpClientService EnsureSuccessStatusCode()
        {
            _ensureSuccessStatusCode = true;
            return this;
        }

        private StringContent CreateStringContent<TData>(TData data)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(data), new MediaTypeHeaderValue("application/json"));
            return content;
        }

        protected HttpClient CreateTransientHttpClient(string baseAddress)
        {
            ValidateUri(baseAddress);

            return new HttpClient()
            {
                BaseAddress = new Uri(baseAddress)
            };
        }

        public static void ValidateUri(string address)
        {
            if (!Uri.TryCreate(address, UriKind.RelativeOrAbsolute, out _))
                throw new InvalidCastException("Invalid URI " + address);
        }
    }
}
