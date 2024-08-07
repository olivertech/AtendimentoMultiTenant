namespace AtendimentoMultiTenant.Web.ManagementArea.Areas.Pages.Dashboard
{
    public class ConfigDashboardHandler : IConfigDashboardHandler
    {
        private readonly HttpClient _httpClient;

        public ConfigDashboardHandler(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(SharedConfigurations.HttpClientName);
        }

        public async Task<ResponseFactory<MenuResponse>> GetAllMenu()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<ResponseFactory<MenuResponse>>("Api/Menu/GetAll");

                if (!response!.IsSuccess)
                    return null!;

                return response ?? new ResponseFactory<MenuResponse>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null!;
            }
        }
    }
}
