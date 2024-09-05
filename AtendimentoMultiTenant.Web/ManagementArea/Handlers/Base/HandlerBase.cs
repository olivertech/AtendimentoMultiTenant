namespace AtendimentoMultiTenant.Web.ManagementArea.Handlers.Base
{
    public class HandlerBase
    {
        protected readonly HttpClient _httpClient;
        protected readonly IStorageService _storageService;

        public HandlerBase(IHttpClientFactory httpClientFactory, IStorageService storageService)
        {
            _httpClient = httpClientFactory.CreateClient(SharedConfigurations.HttpClientName);
            _storageService = storageService;
        }

        public async Task<string?> GetName()
        {
            return await _storageService.GetItem("name");
        }

        public async Task<string?> GetEmail()
        {
            return await _storageService.GetItem("email");
        }

        public async Task<string?> GetUserId()
        {
            return await _storageService.GetItem("userid");
        }

        public async Task<string?> GetRoleId()
        {
            return await _storageService.GetItem("roleid");
        }

        public async Task<string?> GetToken()
        {
            return await _storageService.GetItem("token");
        }
    }
}
