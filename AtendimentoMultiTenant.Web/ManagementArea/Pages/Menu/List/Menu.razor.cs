using AtendimentoMultiTenant.Web.RefitClients;

namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Menu.List
{
    public partial class MenuPage : PageBase
    {
        #region Properties

        public List<MenuResponse>? List = new List<MenuResponse>();

        #endregion

        #region Services

        [Inject]
        public IMenuClient MenuClient { get; set; } = null!;

        #endregion

        #region Methods

        public async Task GetMenus()
        {
            IsBusy = true;
            ResponseFactory<IEnumerable<MenuResponse>>? result = null!;

            try
            {
                result = await MenuClient.GetAll(await SetHeaders());

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

        public void ShowDetails(Guid id)
        {
            try
            {
                IsBusy = true;

                var uri = $"{RoutesEnumerator.MenuDetail.GetDescription()}/{id}";
                NavigationManager.NavigateTo(uri, false, true);
            }
            catch (Exception)
            {
                Snackbar.Add("Não foi possível recuperar os detalhes do menu.", MudBlazor.Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void NewItem()
        {
            NavigationManager.NavigateTo(RoutesEnumerator.MenuDetail.GetDescription(), false, true);
        }

        public async Task DeleteItem(Guid id, string type)
        {
            IsBusy = true;
            ResponseFactory<MenuResponse>? result = null!;

            try
            {
                var token = await StorageService.GetItem("token");

                var headers = new Dictionary<string, string> {
                    { "Authorization", $"Bearer {token}" },
                    { "Content-Type", "application/json" }
                };

                result = await MenuClient.Delete(id, type, headers);

                if (result.IsSuccess)
                {
                    Snackbar.Add(result.Message, MudBlazor.Severity.Success);
                    await GetMenus();
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
