namespace AtendimentoMultiTenant.Web.ManagementArea.Dashboard
{
    public partial class ConfigDashboardPage : PageBase
    {
        #region Properties

        #endregion

        #region Services

        [Inject]
        public IConfigDashboardHandler Handler { get; set; } = null!;

        #endregion

        #region Methods

        #endregion
    }
}
