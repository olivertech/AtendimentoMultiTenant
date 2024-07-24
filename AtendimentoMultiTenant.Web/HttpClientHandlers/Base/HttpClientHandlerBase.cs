namespace AtendimentoMultiTenant.Web.HttpClientHandlers.Base
{
    public class HttpClientHandlerBase
    {
        protected readonly HttpClient _httpClient;

        public HttpClientHandlerBase(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(WebConfigurations.HttpClientName);
        }
    }
}
