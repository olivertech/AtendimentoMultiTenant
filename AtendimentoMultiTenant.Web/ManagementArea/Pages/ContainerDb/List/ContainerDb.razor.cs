namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.ContainerDb.List
{
    public partial class ContainerDbPage : PageBase
    {
        #region Properties

        public List<ContainerDbResponse>? List { get; set; } = new List<ContainerDbResponse>();

        #endregion

        #region Services

        [Inject]
        public IContainerDbClient ContainerDbClient { get; set; } = null!;

        #endregion

        #region Methods

        public async Task GetContainers()
        {
            IsBusy = true;
            ResponseFactory<IEnumerable<ContainerDbResponse>>? result = null!;

            try
            {
                result = await ContainerDbClient.GetAll(await SetHeaders());

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
                NavigationManager.NavigateTo(uri, false, true);
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

        public void NewItem()
        {
            NavigationManager.NavigateTo(RoutesEnumerator.ContainerDetail.GetDescription(), false, true);
        }

        #endregion
    }
}
