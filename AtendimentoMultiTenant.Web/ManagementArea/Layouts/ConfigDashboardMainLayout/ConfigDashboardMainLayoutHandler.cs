namespace AtendimentoMultiTenant.Web.ManagementArea.Layouts.DashboardMainLayout
{
    public class ConfigDashboardMainLayoutHandler : IConfigDashboardMainLayoutHandler
    {
        private readonly HttpClient _httpClient;
        private readonly IStorageService _storageService;

        public ConfigDashboardMainLayoutHandler(IHttpClientFactory httpClientFactory, IStorageService storageService)
        {
            _httpClient = httpClientFactory.CreateClient(SharedConfigurations.HttpClientName);
            _storageService = storageService;
        }

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public void GotoDashboardPage()
        {
            NavigationManager.NavigateTo(RoutesEnumerator.Dashboard.GetDescription(), false, true);
        }

        #region Methods

        public async Task Logout()
        {
            await _storageService!.RemoveItems();
        }

        #endregion
    }
}
