using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace SamStore.WebAPI.Core.Http
{
    public abstract class HttpClientService
    {
        public HttpClient HttpClient { get; set; }

        public async Task<T> GetAsync<T>(string uri)
        {
            HttpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (HttpResponseMessage response = await HttpClient.GetAsync(uri))
            {
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(responseBody);
            }   
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest dataRequest)
        {
            HttpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            StringContent content = new StringContent(JsonConvert.SerializeObject(dataRequest));

            using (HttpResponseMessage response = await HttpClient.PostAsync(uri, content))
            {
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TResponse>(responseBody);
            }
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(string uri, TRequest dataRequest)
        {
            HttpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            StringContent content = new StringContent(JsonConvert.SerializeObject(dataRequest));

            using (HttpResponseMessage response = await HttpClient.PutAsync(uri, content))
            {
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TResponse>(responseBody);
            }
        }

        public async Task<TResponse> PatchAsync<TRequest, TResponse>(string uri, TRequest dataRequest)
        {
            HttpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            StringContent content = new StringContent(JsonConvert.SerializeObject(dataRequest));

            using (HttpResponseMessage response = await HttpClient.PatchAsync(uri, content))
            {
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TResponse>(responseBody);
            }
        }

        public async Task<bool> DeleteAsync<TRequest>(string uri)
        {
            HttpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using HttpResponseMessage response = await HttpClient.DeleteAsync(uri);
            
            return response.IsSuccessStatusCode;
        }
    }
}
