namespace AtendimentoMultiTenant.Web.Interfaces
{
    public interface ILoginHandler
    {
        Task<ResponseFactory<LoginResponse>> Auth(LoginRequest request);
        Task<ResponseFactory<LoginResponse>> Logout(LoginRequest request);
    }
}
