namespace AtendimentoMultiTenant.Web.ManagementArea.Areas.Components.LeftMenu
{
    public class LeftMenuHandler : ILeftMenuHandler
    {
        private readonly HttpClient _httpClient;
        private readonly IStorageService _storageService;

        public LeftMenuHandler(IHttpClientFactory httpClientFactory, IStorageService storageService)
        {
            _httpClient = httpClientFactory.CreateClient(SharedConfigurations.HttpClientName);
            _storageService = storageService;
        }

        public async Task<List<LeftMenuItem>?> GetLeftMenuItens()
        {
            List<LeftMenuItem>? leftMenuItems = new List<LeftMenuItem>();

            var token = await _storageService.GetItem("token");

            var request = new HttpRequestMessage(HttpMethod.Get, "Api/Menu/GetAll")
            { 
                Headers = 
                { 
                    Authorization = new AuthenticationHeaderValue("Bearer", token),
                }
            };
            
            /////MUDAR ESSA LINHA PRO PONTO ONDE INSTANCIO O _httpCliente
            //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var itemsMenu = await response.Content.ReadFromJsonAsync<ResponseFactory<IEnumerable<MenuResponse>>>();

            foreach (var item in itemsMenu!.Content!)
            {
                leftMenuItems.Add(new LeftMenuItem { Key = item.Name, Value = item.Route, Icon = item.Icone });
            }

            return leftMenuItems;
        }
    }

    public class LeftMenuItem
    {
        public string? Key { get; set; }
        public string? Value { get; set; }
        public string? Icon { get; set; }
    }
}
