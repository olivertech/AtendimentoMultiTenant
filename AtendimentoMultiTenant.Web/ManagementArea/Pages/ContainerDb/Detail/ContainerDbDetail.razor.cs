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
            ResponseFactory<ContainerDbResponse> result = null!;

            try
            {
                IsBusy = true;

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

        public void OnValidSubmitAsync()
        {
            IsBusy = true;

            try
            {
                var request = Mapper!.Map<ContainerDbRequest>(InputModel);

                //var result = await Handler.Auth(InputModel);

                //if (result != null)
                //{
                //    if (result.IsSuccess)
                //    {
                //        Snackbar.Add(result.Message, MudBlazor.Severity.Success);
                //        NavigationManager.NavigateTo(RoutesEnumerator.Dashboard.GetDescription());
                //    }
                //    else
                //        Snackbar.Add(result.Message, MudBlazor.Severity.Warning);
                //}
                //else
                //    Snackbar.Add("Não foi possível realizar o login.", MudBlazor.Severity.Error);
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
