namespace AtendimentoMultiTenant.Web.ManagementArea.Pages
{
    public partial class LoginPage : PageBase
    {
        #region Properties

        public bool IsBusy { get; set; } = false;
        public LoginRequest InputModel { get; set; } = new();

        #endregion

        #region Services

        [Inject]
        public ILoginHandler Handler { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public ISessionStorageService sessionStorageService { get; set; } = null!;

        #endregion

        #region Methods

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;

            try
            {
                var result = await Handler.Auth(InputModel);

                if (result != null)
                {
                    if (result.IsSuccess)
                    {
                        List<Item> listItems = new()
                        {
                            new Item { Key = "token", Data = result.Content!.Token },
                            new Item { Key = "name", Data = result.Content!.Name },
                            new Item { Key = "email", Data = result.Content!.Email },
                            new Item { Key = "identifier", Data = result.Content!.Identifier },
                        };

                        await StorageService.SetListItem(listItems);
 
                        Snackbar.Add(result.Message, Severity.Success);
                        NavigationManager.NavigateTo(RoutesEnumerator.Dashboard.GetDescription());
                    }
                    else
                        Snackbar.Add(result.Message, Severity.Warning);
                }
                else
                    Snackbar.Add("Não foi possível realizar o login.", Severity.Error);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion
    }
}
