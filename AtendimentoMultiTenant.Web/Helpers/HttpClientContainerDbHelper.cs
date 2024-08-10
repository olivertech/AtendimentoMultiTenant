
namespace AtendimentoMultiTenant.Web.Helpers
{
    public class HttpClientContainerDbHelper : HttpClientHelper<ContainerDbPagedRequest, ContainerDbResponse>, IHttpClientContainerDbHelper
    {
        public HttpClientContainerDbHelper(IHttpClientFactory httpClientFactory, IStorageService storageService)
             : base(httpClientFactory, storageService)
        {
        }

        public Task<HttpContent> DoPostRequest(string route, ContainerDbPagedRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
