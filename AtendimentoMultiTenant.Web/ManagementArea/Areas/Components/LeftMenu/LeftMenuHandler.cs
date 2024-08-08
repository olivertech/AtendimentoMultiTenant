namespace AtendimentoMultiTenant.Web.ManagementArea.Areas.Components.LeftMenu
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

            var response = await DoGetRequest("Api/Menu/GetAll");

            var itemsMenu = await response.ReadFromJsonAsync<ResponseFactory<IEnumerable<MenuResponse>>>();

            foreach (var item in itemsMenu!.Content!)
            {
                leftMenuItems.Add(new LeftMenuItem { Key = item.Name, Value = item.Route, Icon = item.Icone });
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
