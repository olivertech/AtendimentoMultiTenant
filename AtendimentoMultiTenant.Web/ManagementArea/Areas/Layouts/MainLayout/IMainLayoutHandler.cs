namespace AtendimentoMultiTenant.Web.ManagementArea.Areas.Layouts.MainLayout
{
    public interface IMainLayoutHandler
    {
        Task<ResponseFactory<LoginResponse>> Logout(LoginRequest request);
        void GotoLoginPage();
        void GotoIndexPage();
    }
}
