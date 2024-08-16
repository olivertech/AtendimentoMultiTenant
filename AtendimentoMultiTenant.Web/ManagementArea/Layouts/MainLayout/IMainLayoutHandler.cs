namespace AtendimentoMultiTenant.Web.ManagementArea.Layouts.MainLayout
{
    public interface IMainLayoutHandler
    {
        Task<ResponseFactory<LoginResponse>> Logout(LoginRequest request);
        void GotoLoginPage();
        void GotoIndexPage();
    }
}
