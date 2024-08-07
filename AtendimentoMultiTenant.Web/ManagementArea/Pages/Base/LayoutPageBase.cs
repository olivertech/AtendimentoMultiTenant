namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Base
{
    public class LayoutPageBase : LayoutComponentBase
    {
        #region Properties

        public bool IsBusy { get; set; } = false;

        #endregion

        #region Services

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        #endregion
    }
}
