namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Login
{
    public interface ILoginHandler
    {
        Task<ResponseFactory<LoginResponse>> Auth(LoginRequest request);
    }
}
