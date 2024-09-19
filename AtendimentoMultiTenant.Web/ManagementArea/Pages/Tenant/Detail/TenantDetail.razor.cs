using AtendimentoMultiTenant.Web.RefitClients;

namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Tenant.Detail
{
    public partial class TenantDetailPage : PageBase
    {
        #region Properties

        public TenantResponse InputModel = new();
        ResponseFactory<TenantResponse> Tenant = null!;

        public Guid TenantId { get; set; }

        #endregion

        #region Services

        [Inject]
        public ITenantClient TenantClient { get; set; } = null!;

        [Inject]
        public IMapper? Mapper { get; set; } = null!;

        #endregion

        #region Methods

        public async Task GetTenant(Guid id)
        {
            IsBusy = true;

            try
            {
                Tenant = await TenantClient.GetById(id!, await SetHeaders());

                if (Tenant.IsSuccess)
                {
                    InputModel = Tenant!.Result!;
                    Snackbar.Add(Tenant.Message, MudBlazor.Severity.Success);
                }
                else
                    Snackbar.Add(Tenant.Message, MudBlazor.Severity.Warning);

            }
            catch (Exception)
            {
                Snackbar.Add(Tenant.Message, MudBlazor.Severity.Error);
            }
            finally
            {
                IsBusy = false;
                StateHasChanged();
            }
        }

        public async Task OnValidSubmitAsync()
        {
            ResponseFactory<TenantResponse> result;
            IsBusy = true;

            try
            {
                var token = await StorageService.GetItem("token");

                var headers = new Dictionary<string, string> {
                    { "Authorization", $"Bearer {token}" },
                    { "Content-Type", "application/json" }
                };

                var request = Mapper!.Map<TenantRequest>(InputModel);
                result = request.Id != null ? await TenantClient.Update(request, headers) : await TenantClient.Insert(request, headers);

                if (result != null)
                {
                    if (result.IsSuccess)
                        NavigationManager.NavigateTo(RoutesEnumerator.Tenants.GetDescription(), false, true);
                    else
                        Snackbar.Add(result.Message, MudBlazor.Severity.Warning);
                }
                else
                    Snackbar.Add("Não foi possível salvar os dados do tenant.", MudBlazor.Severity.Error);
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
            NavigationManager.NavigateTo(RoutesEnumerator.Tenants.GetDescription(), false, true);
        }

        public void GoUsers()
        {
            var uri = new Uri(RoutesEnumerator.Users.GetDescription() + "/" + Tenant.Result!.Id);
            NavigationManager.NavigateTo(RoutesEnumerator.Users.GetDescription(), false, true);
        }

        #endregion
    }
}
