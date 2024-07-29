namespace AtendimentoMultiTenant.Web.ManagementArea.Areas.Layouts.DashboardMainLayout
{
    public partial class DashboardMainLayoutPage : LayoutComponentBase
    {
        #region Services

        [Inject]
        public IConfigDashboardMainLayoutHandler Handler { get; set; } = null!;

        #endregion

        #region Methods

        public void GotoTicketListPage()
        {
            Handler.GotoTicketListPage();
        }

        #endregion
    }
}
