using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace SamStore.WebAPI.Core.Http
{
    public abstract class HttpClientService
    {
        protected HttpClient _httpClient;

        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            _httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (HttpResponseMessage response = await _httpClient.GetAsync(uri))
            {
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(responseBody);
            }   
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest dataRequest)
        {
            _httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            StringContent content = new StringContent(JsonConvert.SerializeObject(dataRequest));

            using (HttpResponseMessage response = await _httpClient.PostAsync(uri, content))
            {
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TResponse>(responseBody);
            }
        }

        public async Task<bool> PostAsync<TRequest>(string uri, TRequest dataRequest)
        {
            _httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            StringContent content = new StringContent(JsonConvert.SerializeObject(dataRequest));

            using HttpResponseMessage response = await _httpClient.PostAsync(uri, content);

            return response.IsSuccessStatusCode;
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(string uri, TRequest dataRequest)
        {
            _httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            StringContent content = new StringContent(JsonConvert.SerializeObject(dataRequest));

            using (HttpResponseMessage response = await _httpClient.PutAsync(uri, content))
            {
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TResponse>(responseBody);
            }
        }

        public async Task<bool> PutAsync<TRequest>(string uri, TRequest dataRequest)
        {
            _httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            StringContent content = new StringContent(JsonConvert.SerializeObject(dataRequest));

            using HttpResponseMessage response = await _httpClient.PutAsync(uri, content);

            return response.IsSuccessStatusCode;
        }

        public async Task<TResponse> PatchAsync<TRequest, TResponse>(string uri, TRequest dataRequest)
        {
            _httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            StringContent content = new StringContent(JsonConvert.SerializeObject(dataRequest));

            using (HttpResponseMessage response = await _httpClient.PatchAsync(uri, content))
            {
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TResponse>(responseBody);
            }
        }

        public async Task<bool> PatchAsync<TRequest>(string uri, TRequest dataRequest)
        {
            _httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            StringContent content = new StringContent(JsonConvert.SerializeObject(dataRequest));

            using HttpResponseMessage response = await _httpClient.PatchAsync(uri, content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync<TRequest>(string uri)
        {
            _httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using HttpResponseMessage response = await _httpClient.DeleteAsync(uri);
            
            return response.IsSuccessStatusCode;
        }
    }
}
