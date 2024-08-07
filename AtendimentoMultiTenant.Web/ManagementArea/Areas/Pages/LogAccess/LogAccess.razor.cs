namespace AtendimentoMultiTenant.Web.ManagementArea.Areas.Pages.LogAccess
{
    public partial class LogAccessPage : PageBase 
    {
        #region Properties

        #endregion

        #region Services

        [Inject]
        public ILogAccessHandler Handler { get; set; } = null!;

        #endregion

        #region Methods

        #endregion
    }
}
