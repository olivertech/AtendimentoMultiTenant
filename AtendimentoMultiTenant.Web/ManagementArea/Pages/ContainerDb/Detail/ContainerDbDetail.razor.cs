namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.ContainerDb.Detail
{
    public partial class ContainerDbDetailPage : PageBase
    {
        #region Properties

        public ContainerDbResponse InputModel = new();
        ResponseFactory<ContainerDbResponse> Container = null!;

        public Guid ContainerId { get; set; }

        #endregion

        #region Services

        [Inject]
        public IContainerDbClient ContainerDbClient { get; set; } = null!;

        [Inject]
        public ITenantClient TenantClient { get; set; } = null!;

        [Inject]
        public IMapper? Mapper { get; set; } = null!;

        #endregion

        #region Methods

        public async Task GetContainer(Guid id)
        {
            IsBusy = true;

            try
            {
                Container = await ContainerDbClient.GetById(id!, await SetHeaders());

                if (Container.IsSuccess)
                {
                    InputModel = Container!.Result!;
                    Snackbar.Add(Container.Message, MudBlazor.Severity.Success);
                }
                else
                    Snackbar.Add(Container.Message, MudBlazor.Severity.Warning);

            }
            catch (Exception)
            {
                Snackbar.Add(Container.Message, MudBlazor.Severity.Error);
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
                var token = await StorageService.GetItem("token");

                var headers = new Dictionary<string, string> {
                    { "Authorization", $"Bearer {token}" },
                    { "Content-Type", "application/json" }
                };

                var request = Mapper!.Map<ContainerDbRequest>(InputModel);

                result = request.Id != null ? await ContainerDbClient.Update(request, headers) : await ContainerDbClient.Insert(request, headers);

                if (result != null)
                {
                    if (result.IsSuccess)
                        NavigationManager.NavigateTo(RoutesEnumerator.Containers.GetDescription(), false, true);
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

        public void GoBack()
        {
            NavigationManager.NavigateTo(RoutesEnumerator.Containers.GetDescription(), false, true);
        }

        public void GoTenant()
        {
            var uri = new Uri(RoutesEnumerator.TenantDetail.GetDescription() + "/" + Container.Result!.TenantId);
            NavigationManager.NavigateTo(RoutesEnumerator.TenantDetail.GetDescription(), false, true);
        }

        #endregion
    }
}
