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

        public async void OnTopMenuItemClick(string item)
        {
            if (item == "Sair")
            {
                await Handler.Logout();
                NavigationManager.NavigateTo(RoutesEnumerator.Index.GetDescription(), false, true);
            }
        }

        public void CheckSession()
        {
            StateHasChanged();
        }

        #endregion
    }
}
