using AtendimentoMultiTenant.Web.RefitClients;

namespace AtendimentoMultiTenant.Web.ManagementArea.Login
{
    public partial class LoginPage : PageBase
    {
        #region Properties

        public LoginRequest InputModel { get; set; } = new();

        #endregion

        #region Services

        [Inject]
        public ILoginClient LoginClient { get; set; } = null!;

        [Inject]
        public IStorageService StorageService { get; set; } = null!;

        #endregion

        #region Methods

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;

            try
            {
                var result = await LoginClient.Auth(InputModel);

                if (result != null)
                {
                    if (result.IsSuccess)
                    {
                        // Salva os valores retornados do login em session
                        List<Item> listItems = new()
                        {
                            new Item { Key = "token", Data = result.Result!.AccessToken!.Token! },
                            new Item { Key = "name", Data = result.Result!.Name },
                            new Item { Key = "email", Data = result.Result!.Email },
                            new Item { Key = "userid", Data = result.Result!.Id.ToString() },
                            new Item { Key = "roleid", Data = result.Result!.Role.Id.ToString() },
                        };

                        await StorageService.SetListItem(listItems);

                        Snackbar.Add(result.Message, MudBlazor.Severity.Success);
                        NavigationManager.NavigateTo(RoutesEnumerator.Dashboard.GetDescription(), false, true);
                    }
                    else
                        Snackbar.Add(result.Message, MudBlazor.Severity.Warning);
                }
                else
                    Snackbar.Add("Não foi possível realizar o login.", MudBlazor.Severity.Error);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, MudBlazor.Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion
    }
}
