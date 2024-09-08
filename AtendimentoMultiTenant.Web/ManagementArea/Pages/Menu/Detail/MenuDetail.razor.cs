namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Menu.Detail
{
    public partial class MenuDetailPage : PageBase
    {
        #region Properties

        public MenuResponse InputModel { get; set; } = new();

        public Guid MenuId { get; set; }

        #endregion

        #region Services

        [Inject]
        public IMenuClient MenuClient { get; set; } = null!;

        [Inject]
        public IMapper? Mapper { get; set; } = null!;

        [Inject]
        public IStorageService StorageService { get; set; } = null!;

        #endregion

        #region Methods

        public async Task GetMenu(Guid id)
        {
            IsBusy = true;
            ResponseFactory<MenuResponse> result = null!;

            try
            {
                var token = await StorageService.GetItem("token");

                var headers = new Dictionary<string, string> {
                    { "Authorization", $"Bearer {token}" },
                    { "Content-Type", "application/json" }
                };

                result = await MenuClient.GetById(id!, headers);

                if (result.IsSuccess)
                    InputModel = result!.Result!;
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

        public void OnInvalidSubmit()
        {
            Snackbar.Add("Preencha o formuário corretamente", MudBlazor.Severity.Warning);
        }

        public async Task OnValidSubmitAsync()
        {
            ResponseFactory<MenuResponse> result = new();
            IsBusy = true;

            try
            {
                var request = Mapper!.Map<MenuRequest>(InputModel);

                var token = await StorageService.GetItem("token");

                var headers = new Dictionary<string, string> {
                    { "Authorization", $"Bearer {token}" },
                    { "Content-Type", "application/json" }
                };

                result = request.Id == Guid.Empty ? await MenuClient.Insert(request, headers) : await MenuClient.Update(request, headers);

                if (result != null)
                {
                    if (result.IsSuccess)
                    {
                        Snackbar.Add(result.Message, MudBlazor.Severity.Success);
                        NavigationManager.NavigateTo(RoutesEnumerator.Menus.GetDescription(), false, true);
                    }
                    else
                        Snackbar.Add(result.Message, MudBlazor.Severity.Warning);
                }
                else
                    Snackbar.Add("Não foi possível salvar os dados do menu.", MudBlazor.Severity.Error);
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

        public void GoBack()
        {
            NavigationManager.NavigateTo(RoutesEnumerator.Menus.GetDescription(), false, true);
        }

        #endregion
    }
}
