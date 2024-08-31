namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Feature.List
{
    public partial class FeaturePage : PageBase
    {
        #region Properties

        public List<FeatureResponse>? List = new List<FeatureResponse>();

        #endregion

        #region Services

        [Inject]
        public IFeatureHandler Handler { get; set; } = null!;

        [Inject]
        public IMapper? Mapper { get; set; } = null!;

        #endregion

        #region Methods

        public async Task GetFeatures()
        {
            IsBusy = true;
            ResponseFactory<IEnumerable<FeatureResponse>>? result = null!;

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

        public void ShowDetails(Guid? id)
        {
            try
            {
                IsBusy = true;

                var uri = $"{RoutesEnumerator.FeatureDetail.GetDescription()}/{id}";
                NavigationManager.NavigateTo(uri, false, true);
            }
            catch (Exception)
            {
                Snackbar.Add("Não foi possível recuperar os detalhes da feature.", MudBlazor.Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void NewItem()
        {
            NavigationManager.NavigateTo(RoutesEnumerator.FeatureDetail.GetDescription(), false, true);
        }

        public async Task DeleteItem(Guid id, string type)
        {
            IsBusy = true;
            ResponseFactory<FeatureResponse>? result = null!;

            try
            {
                result = await Handler.Delete(id, type);

                if (result.IsSuccess)
                {
                    Snackbar.Add(result.Message, MudBlazor.Severity.Success);
                    await GetFeatures();
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
