namespace AtendimentoMultiTenant.Web.RefitClients
{
    public interface IFeatureClient
    {
        [Get("/Api/Feature/GetAll")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<IEnumerable<FeatureResponse>>> GetAll([HeaderCollection] IDictionary<string, string> headers);

        [Delete("/Api/Feature/Delete/{id}/{type}")]
        [Headers("Authorization: Bearer")]
        Task<ResponseFactory<FeatureResponse>> Delete(Guid id, string type, [HeaderCollection] IDictionary<string, string> headers);
    }
}
