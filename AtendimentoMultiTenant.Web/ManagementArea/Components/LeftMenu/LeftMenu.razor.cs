using AtendimentoMultiTenant.Web.RefitClients;

namespace AtendimentoMultiTenant.Web.ManagementArea.Areas.Components.LeftMenu
{
    public partial class LeftMenuPage : PageBase
    {
        #region Properties

        public List<LeftMenuItem>? LeftMenuItems { get; set; } = new List<LeftMenuItem>();

        #endregion

        #region Services

        [Inject]
        public IMenuClient MenuClient { get; set; } = null!;

        [Inject]
        public IStorageService StorageService { get; set; } = null!;

        #endregion

        #region Methods

        public async void BuildLeftMenu()
        {
            IsBusy = true;

            try
            {
                var token = await StorageService.GetItem("token");

                var headers = new Dictionary<string, string> { 
                    { "Authorization", $"Bearer {token}" }, 
                    { "Content-Type", "application/json" } 
                };

                var result = await MenuClient.GetLeftMenuItens(headers);

                if(result != null)
                {
                    if(result.IsSuccess)
                    {
                        foreach (var item in result!.Result!)
                        {
                            LeftMenuItems!.Add(new LeftMenuItem { Key = item.Name, Value = item.Route, Icon = item.Icone });
                        }
                    }
                }
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

    public class LeftMenuItem
    {
        public string? Key { get; set; }
        public string? Value { get; set; }
        public string? Icon { get; set; }
    }
}
