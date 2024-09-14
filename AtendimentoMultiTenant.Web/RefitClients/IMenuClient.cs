namespace AtendimentoMultiTenant.Web.RefitClients
{
    public interface IMenuClient
    {
        [Get("/Api/Menu/GetAll")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<IEnumerable<MenuResponse>>> GetAll([HeaderCollection] IDictionary<string, string> headers);

        [Get("/Api/Menu/GetAll")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<MenuResponse>> GetAllMenu([HeaderCollection] IDictionary<string, string> headers);

        [Get("/Api/Menu/GetById/{id}")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<MenuResponse>> GetById(Guid id, [HeaderCollection] IDictionary<string, string> headers);

        [Get("/Api/Menu/GetLeftMenuItens/{roleId}")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<IEnumerable<MenuResponse>>> GetLeftMenuItens(Guid roleId, [HeaderCollection] IDictionary<string, string> headers);

        [Post("/Api/Menu/Insert")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<MenuResponse>> Insert(MenuRequest request, [HeaderCollection] IDictionary<string, string> headers);

        [Put("/Api/Menu/Update")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<MenuResponse>> Update(MenuRequest request, [HeaderCollection] IDictionary<string, string> headers);

        [Delete("/Api/Menu/Delete/{id}/{type}")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<MenuResponse>> Delete(Guid id, string type, [HeaderCollection] IDictionary<string, string> headers);
    }
}
