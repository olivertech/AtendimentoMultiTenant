namespace AtendimentoMultiTenant.Web.Interfaces
{
    public interface ILoginHttpClientHandler
    {
        Task<ResponseFactory<LoginResponse>> Auth(LoginRequest request);
        Task<ResponseFactory<LoginResponse>> Logout(LoginRequest request);
    }
}
