namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Menu
{
    public partial class MenuPage : PageBase
    {
        #region Properties

        public List<MenuResponse>? List = new List<MenuResponse>();

        #endregion

        #region Services

        [Inject]
        public IMenuHandler Handler { get; set; } = null!;

        [Inject]
        public IMapper? Mapper { get; set; } = null!;

        #endregion

        #region Methods

        public async Task GetMenus()
        {
            IsBusy = true;
            ResponseFactory<IEnumerable<MenuResponse>>? result = null!;

            try
            {
                result = await Handler.GetAll();

                if (result.IsSuccess)
                {
                    List = result.Result!.ToList();
                    Snackbar.Add(result.Message, MudBlazor.Severity.Success);
                }
                else
                    Snackbar.Add(result.Message, MudBlazor.Severity.Warning);
            }
            catch (Exception)
            {
                Snackbar.Add(result.Message, MudBlazor.Severity.Error);
            }
            finally
            {
                IsBusy = false;
                StateHasChanged();
            }
        }

        #endregion
    }
}
