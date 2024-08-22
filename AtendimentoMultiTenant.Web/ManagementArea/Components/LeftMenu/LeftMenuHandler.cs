namespace AtendimentoMultiTenant.Web.ManagementArea.Components.LeftMenu
{
    public class LeftMenuHandler : HandlerBase, ILeftMenuHandler
    {
        public LeftMenuHandler(IHttpClientFactory httpClientFactory, IStorageService storageService)
            : base(httpClientFactory, storageService)
        {
        }

        public async Task<List<LeftMenuItem>?> GetLeftMenuItens()
        {
            List<LeftMenuItem>? leftMenuItems = new List<LeftMenuItem>();

            try
            {
                var token = await _storageService.GetItem("token");

                if (token != null)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var request = new HttpRequestMessage(HttpMethod.Get, "Api/Menu/GetAllForLeftMenu");

                    var response = await _httpClient.SendAsync(request);
                    var itemsMenu = await response.Content.ReadFromJsonAsync<ResponseFactory<IEnumerable<MenuResponse>>>();

                    response.EnsureSuccessStatusCode();

                    foreach (var item in itemsMenu!.Result!)
                    {
                        leftMenuItems.Add(new LeftMenuItem { Key = item.Name, Value = item.Route, Icon = item.Icone });
                    }
                }
                else
                {
                    throw new KeyNotFoundException("Token not found!");
                }
            }
            catch(KeyNotFoundException)
            {
                throw;
            }

            return leftMenuItems;
        }
    }
}

public class LeftMenuItem
{
    public string? Key { get; set; }
    public string? Value { get; set; }
    public string? Icon { get; set; }
}
