namespace AtendimentoMultiTenant.Web.RefitClients
{
    public interface IRoleMenuClient
    {
        [Get("/Api/RoleMenu/GetAll")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<IEnumerable<RoleMenuResponse>>> GetAll([HeaderCollection] IDictionary<string, string> headers);

        [Get("/Api/RoleMenu/GetById")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<RoleMenuResponse>> GetById(Guid id, [HeaderCollection] IDictionary<string, string> headers);

        [Get("/Api/RoleMenu/GetAllByRoleId/{roleId}")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<IEnumerable<RoleMenuResponse>>> GetRoleMenuList(string roleId, [HeaderCollection] IDictionary<string, string> headers);

        [Post("/Api/RoleMenu/Insert")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<RoleMenuResponse>> Insert(RoleMenuRequest request, [HeaderCollection] IDictionary<string, string> headers);

        [Put("/Api/RoleMenu/Update")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<RoleMenuResponse>> Update(RoleMenuRequest request, [HeaderCollection] IDictionary<string, string> headers);

        [Delete("/Api/RoleMenu/Delete/{id}")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<RoleMenuResponse>> Delete(Guid id, [HeaderCollection] IDictionary<string, string> headers);
    }
}
