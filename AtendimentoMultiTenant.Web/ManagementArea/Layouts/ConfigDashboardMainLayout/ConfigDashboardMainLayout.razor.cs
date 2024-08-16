namespace AtendimentoMultiTenant.Web.ManagementArea.Layouts.DashboardMainLayout
{
    public partial class DashboardMainLayoutPage : LayoutPageBase
    {
        #region Properties

        public List<string>? TopMenuItems { get; set; } = new();

        #endregion

        #region Services

        [Inject]
        public IConfigDashboardMainLayoutHandler Handler { get; set; } = null!;

        #endregion

        #region Methods

        public void BuildTopMenu()
        {
            TopMenuItems!.Add("Sair");
        }

        public void OnTopMenuItemClick(string item)
        {
            if (item == "Sair")
            {
                NavigationManager.NavigateTo(RoutesEnumerator.Index.GetDescription());
            }
        }

        #endregion
    }
}
