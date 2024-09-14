namespace AtendimentoMultiTenant.Web.RefitClients
{
    public interface ITenantClient
    {
        [Get("/Api/Tenant/GetAll")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<IEnumerable<TenantResponse>>> GetAll([HeaderCollection] IDictionary<string, string> headers);

        [Get("/Api/Tenant/GetById/{id}")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<TenantResponse>> GetById(Guid id, [HeaderCollection] IDictionary<string, string> headers);

        [Post("/Api/Tenant/Insert")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<TenantResponse>> Insert(TenantRequest request, [HeaderCollection] IDictionary<string, string> headers);

        [Put("/Api/Tenant/Update")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<TenantResponse>> Update(TenantRequest request, [HeaderCollection] IDictionary<string, string> headers);

        [Delete("/Api/Tenant/Delete/{id}")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<TenantResponse>> Delete(Guid id, [HeaderCollection] IDictionary<string, string> headers);
    }
}
