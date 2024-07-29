namespace AtendimentoMultiTenant.Web.ManagementArea.Areas.Login
{
    public partial class LoginPage : PageBase
    {
        #region Properties

        public LoginRequest InputModel { get; set; } = new();

        #endregion

        #region Services

        [Inject]
        public ILoginHandler Handler { get; set; } = null!;

        #endregion

        #region Methods

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;

            try
            {
                var result = await Handler.Auth(InputModel);

                if (result != null)
                {
                    if (result.IsSuccess)
                    {
                        Snackbar.Add(result.Message, Severity.Success);
                        NavigationManager.NavigateTo(RoutesEnumerator.Dashboard.GetDescription());
                    }
                    else
                        Snackbar.Add(result.Message, Severity.Warning);
                }
                else
                    Snackbar.Add("Não foi possível realizar o login.", Severity.Error);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion
    }
}
