namespace AtendimentoMultiTenant.Web.RefitClients
{
    public interface IContainerDbClient
    {
        [Get("/Api/ContainerDb/GetAll")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<IEnumerable<ContainerDbResponse>>> GetAll([HeaderCollection] IDictionary<string, string> headers);

        [Get("/Api/ContainerDb/GetById/{id}")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<ContainerDbResponse>> GetById(Guid id, [HeaderCollection] IDictionary<string, string> headers);

        [Post("/Api/ContainerDb/Insert")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<ContainerDbResponse>> Insert(ContainerDbRequest request, [HeaderCollection] IDictionary<string, string> headers);

        [Put("/Api/ContainerDb/Update")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<ContainerDbResponse>> Update(ContainerDbRequest request, [HeaderCollection] IDictionary<string, string> headers);
    }
}
