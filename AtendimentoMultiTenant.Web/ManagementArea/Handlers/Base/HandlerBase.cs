namespace AtendimentoMultiTenant.Web.ManagementArea.Handlers.Base
{
    public class HandlerBase
    {
        protected readonly HttpClient _httpClient;
        protected readonly IStorageService _storageService;

        public HandlerBase(IHttpClientFactory httpClientFactory, IStorageService storageService)
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
    }
}
