namespace AtendimentoMultiTenant.Web.ManagementArea.Areas.Components.LeftMenu
{
    public partial class LeftMenuPage : PageBase
    {
        #region Properties

        public List<LeftMenuItem>? LeftMenuItems { get; set; } = new List<LeftMenuItem>();

        #endregion

        #region Services

        [Inject]
        public ILeftMenuHandler Handler { get; set; } = null!;

        #endregion

        #region Methods

        public async void BuildLeftMenu()
        {
            IsBusy = true;

            try
            {
                LeftMenuItems = await Handler.GetLeftMenuItens();
            }
            catch (KeyNotFoundException)
            {
                NavigationManager.NavigateTo(RoutesEnumerator.Error.GetDescription(), false, true);
            }
            catch (Exception)
            {
                Snackbar.Add("Não foi possível recuperar os itens do menu lateral.", MudBlazor.Severity.Error);
            }
            finally
            {
                IsBusy = false;
                StateHasChanged();
            }
        }

        public void GotoPage(string page)
        {
            NavigationManager.NavigateTo(page, false, true);
        }

        #endregion
    }
}
