using System.Text.Json;

namespace AtendimentoMultiTenant.Web.Helpers
{
    public class HttpClientHelper<T,Z> 
        where T : IRequest
        where Z : IResponse    
    {
        protected readonly HttpClient _httpClient;
        protected readonly IStorageService _storageService;

        public HttpClientHelper(IHttpClientFactory httpClientFactory, IStorageService storageService)
        {
            _httpClient = httpClientFactory.CreateClient(SharedConfigurations.HttpClientName);
            _storageService = storageService;
        }

        public async Task<HttpContent> DoGetRequest(string route)
        {
            var token = await _storageService.GetItem("token");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var request = new HttpRequestMessage(HttpMethod.Get, route);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return response.Content;
        }

        public async Task<Z> DoPostRequest(string route, T request, Z response)
        {
            var token = await _storageService.GetItem("token");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var result = await _httpClient.PostAsJsonAsync(route, request);
            var data = await result.Content.ReadFromJsonAsync<Z>();

            return data!;
        }
    }
}
