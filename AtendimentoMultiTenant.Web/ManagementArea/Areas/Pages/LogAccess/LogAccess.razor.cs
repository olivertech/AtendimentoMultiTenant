namespace AtendimentoMultiTenant.Web.ManagementArea.Areas.Pages.LogAccess
{
    public partial class LogAccessPage : PageBase
    {
        #region Properties

        public List<LogAccessResponse>? List = new List<LogAccessResponse>();

        #endregion

        #region Services

        [Inject]
        public ILogAccessHandler Handler { get; set; } = null!;

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
                //LogAccessPagedRequest request = new LogAccessPagedRequest
                //{
                //    PageSize = SharedConfigurations.PageSize,
                //    PageNumber = pageNumber,
                //};

                //var result = await Handler.GetAll(request);

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

        #endregion
    }
}
