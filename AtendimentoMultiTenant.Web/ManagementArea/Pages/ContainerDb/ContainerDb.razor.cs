namespace AtendimentoMultiTenant.Web.ManagementArea.ContainerDb
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
                    Snackbar.Add(result.Message, Severity.Success);
                }
                else
                    Snackbar.Add(result.Message, Severity.Warning);
            }
            catch (Exception)
            {
                Snackbar.Add(result.Message, Severity.Error);
            }
            finally
            {
                IsBusy = false;
                StateHasChanged();
            }
        }

        public async Task GetDetails(Guid id)
        {
            ResponseFactory<ContainerDbResponse> result = null!;

            try
            {
                IsBusy = true;

                var guid = id;
                result = await Handler.GetById(id);

                if (result.IsSuccess)
                {
                    NavigationManager.NavigateTo(RoutesEnumerator.ContainerDetail.GetDescription());
                }
                else
                    Snackbar.Add(result.Message, Severity.Warning);

            }
            catch (Exception)
            {
                Snackbar.Add(result.Message, Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion
    }
}
