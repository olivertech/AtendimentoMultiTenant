using Refit;

namespace AtendimentoMultiTenant.Web.RefitClients
{
    public interface IContainerDbClient
    {
        [Get("/Api/ContainerDb/GetAll")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<IEnumerable<ContainerDbResponse>>> GetAll([HeaderCollection] IDictionary<string, string> headers);
    }
}
