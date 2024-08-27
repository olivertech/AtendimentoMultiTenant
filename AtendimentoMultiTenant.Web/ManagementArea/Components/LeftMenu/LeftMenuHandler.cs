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
            ResponseFactory<IEnumerable<MenuResponse>>? result = null!;
            List<LeftMenuItem>? leftMenuItems = new List<LeftMenuItem>();

            try
            {
                var token = await _storageService.GetItem("token");

                if (token != null)
                {
                    var requestMessage = new HttpRequestMessage(HttpMethod.Get, "Api/Menu/GetAllForLeftMenu");

                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await _httpClient.SendAsync(requestMessage);

                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<ResponseFactory<IEnumerable<MenuResponse>>>(response.Content.ReadAsStringAsync().Result);
                    }

                    response.EnsureSuccessStatusCode();

                    foreach (var item in result!.Result!)
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
