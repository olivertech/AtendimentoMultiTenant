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
    }
}
