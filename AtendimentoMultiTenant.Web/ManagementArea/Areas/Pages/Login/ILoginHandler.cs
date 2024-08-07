namespace AtendimentoMultiTenant.Web.ManagementArea.Areas.Pages.Login
{
    public interface ILoginHandler
    {
        Task<ResponseFactory<LoginResponse>> Auth(LoginRequest request);
    }
}
