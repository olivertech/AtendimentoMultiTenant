namespace AtendimentoMultiTenant.Web.ManagementArea.Layouts.MainLayout
{
    public partial class MainLayoutPage : LayoutComponentBase
    {
        #region Properties

        #endregion

        #region Services

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        #endregion

        #region Methods

        public void GotoLoginPage()
        {
            NavigationManager.NavigateTo(RoutesEnumerator.Login.GetDescription(), false, true);
        }

        public void GotoIndexPage()
        {
            NavigationManager.NavigateTo(RoutesEnumerator.Index.GetDescription(), false, true);
        }

        #endregion
    }
}
