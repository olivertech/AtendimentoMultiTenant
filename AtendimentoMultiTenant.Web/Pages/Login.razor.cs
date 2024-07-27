using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AtendimentoMultiTenant.Web.Pages
{
    public partial class LoginPage : ComponentBase
    {
        #region Properties

        public bool IsBusy { get; set; } = false;
        public LoginRequest InputModel { get; set; } = new();

        #endregion

        #region Services

        [Inject]
        public ILoginHandler Handler { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

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
                        NavigationManager.NavigateTo("/home");
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
