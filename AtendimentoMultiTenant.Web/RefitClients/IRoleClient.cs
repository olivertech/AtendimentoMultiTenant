namespace AtendimentoMultiTenant.Web.RefitClients
{
    public interface IRoleClient
    {
        [Get("/Api/Role/GetAll")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<IEnumerable<RoleResponse>>> GetAll([HeaderCollection] IDictionary<string, string> headers);

        [Get("/Api/Role/GetById/{id}")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<RoleResponse>> GetById(Guid id, [HeaderCollection] IDictionary<string, string> headers);

        [Post("/Api/Role/Insert")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<RoleResponse>> Insert(RoleRequest request, [HeaderCollection] IDictionary<string, string> headers);

        [Put("/Api/Role/Update")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<RoleResponse>> Update(RoleRequest request, [HeaderCollection] IDictionary<string, string> headers);

        [Delete("/Api/Role/Delete/{id}")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<RoleResponse>> Delete(Guid id, [HeaderCollection] IDictionary<string, string> headers);
    }
}
