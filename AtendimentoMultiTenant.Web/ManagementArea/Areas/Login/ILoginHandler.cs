namespace AtendimentoMultiTenant.Web.ManagementArea.Areas.Login
{
    public interface ILoginHandler
    {
        Task<ResponseFactory<LoginResponse>> Auth(LoginRequest request);
    }
}
