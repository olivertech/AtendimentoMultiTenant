namespace AtendimentoMultiTenant.Web.RefitClients
{
    public interface ILoginClient
    {
        [Post("/Api/Login/Auth")]
        Task<ResponseFactory<LoginResponse>> Auth(LoginRequest request);
    }
}
