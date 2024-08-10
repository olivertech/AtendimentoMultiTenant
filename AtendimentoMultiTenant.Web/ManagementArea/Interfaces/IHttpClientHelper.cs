namespace AtendimentoMultiTenant.Web.ManagementArea.Interfaces
{
    public interface IHttpClientHelper<T> where T : IRequest
    {
        Task<HttpContent> DoGetRequest(string route);
        Task<HttpContent> DoPostRequest(string route, T request);
    }
}
