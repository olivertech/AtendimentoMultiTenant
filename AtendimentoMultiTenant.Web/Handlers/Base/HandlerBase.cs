namespace AtendimentoMultiTenant.Web.HttpClientHandlers.Base
{
    public class HandlerBase
    {
        protected readonly HttpClient _httpClient;

        public HandlerBase(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(SharedConfigurations.HttpClientName);
        }
    }
}
