namespace AtendimentoMultiTenant.Web.ManagementArea.Areas.Layouts.MainLayout
{
    public partial class MainLayoutPage : LayoutComponentBase
    {
        #region Properties

        #endregion

        #region Services

        [Inject]
        public IMainLayoutHandler Handler { get; set; } = null!;

        #endregion

        #region Methods

        public void GotoLoginPage()
        {
            Handler.GotoLoginPage();
        }

        public void GotoIndexPage()
        {
            Handler.GotoIndexPage();
        }

        #endregion
    }
}
