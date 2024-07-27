namespace AtendimentoMultiTenant.Web.CommonArea
{
    public static class StorageService
    {
        #region Services

        [Inject]
        public static ISessionStorageService sessionStorageService { get; set; } = null!;

        #endregion

        #region Methods

        public async static Task SetItem(string key, string data)
        {
            await sessionStorageService.SetItemAsync(key, data);
        }

        public async static Task SetListItem(IEnumerable<Item> listItems)
        {
            foreach (var item in listItems)
            {
                await sessionStorageService.SetItemAsync(item.Key, item.Data);
            }
        }

        public async static Task GetItem(string key)
        {
            await sessionStorageService.GetItemAsync<string>(key);
        }

        #endregion
    }

    public class Item
    {
        public string Key { get; set; } = null!;
        public string Data { get; set; } = null!;
    }
}
