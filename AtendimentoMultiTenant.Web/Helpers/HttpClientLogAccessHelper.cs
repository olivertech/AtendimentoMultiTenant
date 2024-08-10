
namespace AtendimentoMultiTenant.Web.Helpers
{
    public class HttpClientLogAccessHelper : HttpClientHelper<LogAccessPagedRequest, LogAccessResponse>, IHttpClientLogAccessHelper
    {
        public HttpClientLogAccessHelper(IHttpClientFactory httpClientFactory, IStorageService storageService)
             : base(httpClientFactory, storageService)
        {
        }

        public Task<HttpContent> DoPostRequest(string route, LogAccessPagedRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
