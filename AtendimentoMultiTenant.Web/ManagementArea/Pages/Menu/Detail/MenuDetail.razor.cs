namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Menu.Detail
{
    public partial class MenuDetailPage : PageBase
    {
        #region Properties

        public MenuResponse InputModel = new();

        public Guid MenuId { get; set; }

        #endregion

        #region Services

        [Inject]
        public IMenuDetailHandler Handler { get; set; } = null!;

        [Inject]
        public IMapper? Mapper { get; set; } = null!;

        #endregion

        #region Methods

        public async Task GetMenu(Guid id)
        {
            IsBusy = true;
            ResponseFactory<MenuResponse> result = null!;

            try
            {
                result = await Handler.GetById(id!);

                if (result.IsSuccess)
                {
                    InputModel = result!.Result!;
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

        public void OnInvalidSubmit()
        {
            Snackbar.Add("Preencha o formuário corretamente", MudBlazor.Severity.Warning);
        }

        public async Task OnValidSubmitAsync()
        {
            ResponseFactory<MenuResponse> result;
            IsBusy = true;

            try
            {
                var request = Mapper!.Map<MenuRequest>(InputModel);

                result = request.Id != null ? await Handler.Update(request) : await Handler.Insert(request);

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

        #endregion
    }
}
