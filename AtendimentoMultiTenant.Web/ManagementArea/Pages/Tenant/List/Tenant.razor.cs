using AtendimentoMultiTenant.Web.RefitClients;

namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Tenant.List
{
    public partial class TenantPage : PageBase
    {
        #region Properties

        public List<TenantResponse>? List = new List<TenantResponse>();

        #endregion

        #region Services

        [Inject]
        public ITenantClient TenantClient { get; set; } = null!;

        [Inject]
        public IMapper? Mapper { get; set; } = null!;

        #endregion

        #region Methods

        public async Task GetTenants()
        {
            IsBusy = true;
            ResponseFactory<IEnumerable<TenantResponse>>? result = null!;

            try
            {
                result = await TenantClient.GetAll(await SetHeaders());

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

                var uri = $"{RoutesEnumerator.TenantDetail.GetDescription()}/{id}";
                NavigationManager.NavigateTo(uri, false, true);
            }
            catch (Exception)
            {
                Snackbar.Add("Não foi possível recuperar os detalhes do tenant.", MudBlazor.Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void NewItem()
        {
            NavigationManager.NavigateTo(RoutesEnumerator.TenantDetail.GetDescription(), false, true);
        }

        public async Task DeleteItem(Guid id)
        {
            IsBusy = true;
            ResponseFactory<TenantResponse>? result = null!;

            try
            {
                result = await TenantClient.Delete(id, await SetHeaders());

                if (result.IsSuccess)
                {
                    Snackbar.Add(result.Message, MudBlazor.Severity.Success);
                    await GetTenants();
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
