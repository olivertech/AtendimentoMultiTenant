using Refit;

namespace AtendimentoMultiTenant.Web.RefitClients
{
    public interface IMenuClient
    {
        [Get("/Api/Menu/GetAllForLeftMenu")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<IEnumerable<MenuResponse>>> GetLeftMenuItens([HeaderCollection] IDictionary<string, string> headers);
    }
}
