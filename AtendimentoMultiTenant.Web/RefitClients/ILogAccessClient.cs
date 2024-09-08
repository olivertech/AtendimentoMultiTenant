namespace AtendimentoMultiTenant.Web.RefitClients
{
    public interface ILogAccessClient
    {
        [Get("/Api/LogAccess/GetAll")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<IEnumerable<LogAccessResponse>>> GetAll([HeaderCollection] IDictionary<string, string> headers);
    }
}
