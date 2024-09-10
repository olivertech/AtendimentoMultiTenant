namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Role.List
{
    public partial class RolePage : PageBase
    {
        #region Properties

        public List<RoleResponse>? List = new List<RoleResponse>();

        #endregion

        #region Services

        [Inject]
        public IRoleClient RoleClient { get; set; } = null!;

        [Inject]
        public IMapper? Mapper { get; set; } = null!;

        #endregion

        #region Methods

        public async Task GetRoles()
        {
            IsBusy = true;
            ResponseFactory<IEnumerable<RoleResponse>>? result = null!;

            try
            {
                result = await RoleClient.GetAll(await SetHeaders());

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

                var uri = $"{RoutesEnumerator.RoleDetail.GetDescription()}/{id}";
                NavigationManager.NavigateTo(uri, false, true);
            }
            catch (Exception)
            {
                Snackbar.Add("Não foi possível recuperar os detalhes do role.", MudBlazor.Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void NewItem()
        {
            NavigationManager.NavigateTo(RoutesEnumerator.RoleDetail.GetDescription(), false, true);
        }

        public async Task DeleteItem(Guid id)
        {
            IsBusy = true;
            ResponseFactory<RoleResponse>? result = null!;

            try
            {
                result = await RoleClient.Delete(id, await SetHeaders());

                if (result.IsSuccess)
                {
                    Snackbar.Add(result.Message, MudBlazor.Severity.Success);
                    await GetRoles();
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
