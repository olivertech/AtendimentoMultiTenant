namespace AtendimentoMultiTenant.Web.ManagementArea.Areas.Layouts.DashboardMainLayout
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
            NavigationManager.NavigateTo(RoutesEnumerator.Dashboard.GetDescription());
        }

        public void GotoTicketListPage()
        {
            NavigationManager.NavigateTo(RoutesEnumerator.TicketList.GetDescription());
        }
    }
}
