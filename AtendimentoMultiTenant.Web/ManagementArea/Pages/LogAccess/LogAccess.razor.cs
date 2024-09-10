namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.LogAccess
{
    public partial class LogAccessPage : PageBase
    {
        #region Properties

        public List<LogAccessResponse>? List = new List<LogAccessResponse>();

        #endregion

        #region Services

        [Inject]
        public ILogAccessClient LogAccessClient { get; set; } = null!;

        [Inject]
        public IMapper? Mapper { get; set; } = null!;

        #endregion

        #region Methods

        public async Task GetLogAccesses()
        {
            IsBusy = true;
            ResponseFactory<IEnumerable<LogAccessResponse>>? result = null!;

            try
            {
                result = await LogAccessClient.GetAll(await SetHeaders());

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

        #endregion
    }
}
