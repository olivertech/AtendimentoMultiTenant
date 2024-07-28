namespace AtendimentoMultiTenant.Web.CommonArea.Services
{
    public class StorageService : IStorageService
    {
        private readonly ISessionStorageService _sessionStorageService;

        #region Constructor

        public StorageService(ISessionStorageService sessionStorageService)
        {
            _sessionStorageService = sessionStorageService;
        }

        #endregion

        #region Services

        #endregion

        #region Methods

        public async Task SetItem(string key, string data)
        {
            await _sessionStorageService!.SetItemAsync(key, data);
        }

        public async Task SetListItem(IEnumerable<Item> listItems)
        {
            foreach (var item in listItems)
            {
                await _sessionStorageService!.SetItemAsync(item.Key, item.Data);
            }
        }

        public async Task GetItem(string key)
        {
            await _sessionStorageService!.GetItemAsync<string>(key);
        }

        #endregion
    }

    public class Item
    {
        public string Key { get; set; } = null!;
        public string Data { get; set; } = null!;
    }
}
