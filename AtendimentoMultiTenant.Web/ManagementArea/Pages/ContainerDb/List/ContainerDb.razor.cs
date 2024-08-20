namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.ContainerDb.List
{
    public partial class ContainerDbPage : PageBase
    {
        #region Properties

        public List<ContainerDbResponse>? List = new List<ContainerDbResponse>();

        #endregion

        #region Services

        [Inject]
        public IContainerDbHandler Handler { get; set; } = null!;

        [Inject]
        public IMapper? Mapper { get; set; } = null!;

        #endregion

        #region Methods

        public async Task GetContainers()
        {
            IsBusy = true;
            ResponseFactory<IEnumerable<ContainerDbResponse>>? result = null!;

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

        public void ShowDetails(Guid id)
        {
            try
            {
                IsBusy = true;

                var uri = $"{RoutesEnumerator.ContainerDetail.GetDescription()}/{id}";
                NavigationManager.NavigateTo(uri);
            }
            catch (Exception)
            {
                Snackbar.Add("Não foi possível recuperar os detalhes do container.", MudBlazor.Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion
    }
}
