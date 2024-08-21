namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.ContainerDb.Detail
{
    public partial class ContainerDbDetailPage : PageBase
    {
        #region Properties

        public ContainerDbResponse InputModel = new();

        public Guid ContainerId { get; set; }

        #endregion

        #region Services

        [Inject]
        public IContainerDbDetailHandler Handler { get; set; } = null!;

        [Inject]
        public IMapper? Mapper { get; set; } = null!;

        #endregion

        #region Methods

        public async Task GetContainer(Guid id)
        {
            IsBusy = true;
            ResponseFactory<ContainerDbResponse> result = null!;

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

        public async Task OnValidSubmitAsync()
        {
            ResponseFactory<ContainerDbResponse> result;
            IsBusy = true;

            try
            {
                var request = Mapper!.Map<ContainerDbRequest>(InputModel);

                result = request.Id != null ? await Handler.Update(request) : await Handler.Insert(request);

                if (result != null)
                {
                    if (result.IsSuccess)
                    {
                        Snackbar.Add(result.Message, MudBlazor.Severity.Success);
                        NavigationManager.NavigateTo(RoutesEnumerator.Containers.GetDescription());
                    }
                    else
                        Snackbar.Add(result.Message, MudBlazor.Severity.Warning);
                }
                else
                    Snackbar.Add("Não foi possível salvar os dados do container.", MudBlazor.Severity.Error);
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
