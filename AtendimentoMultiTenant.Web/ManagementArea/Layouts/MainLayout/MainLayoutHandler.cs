namespace AtendimentoMultiTenant.Web.ManagementArea.Layouts.MainLayout
{
    public class MainLayoutHandler  : IMainLayoutHandler
    {
        //private readonly HttpClient _httpClient;
        //private readonly IStorageService? _storageService = null!;
        //private string userName = null!;
        //public List<string> _menuItems = null!;

        //public MainLayoutHandler(IHttpClientFactory httpClientFactory, IStorageService storageService)
        //{
        //    _httpClient = httpClientFactory.CreateClient(SharedConfigurations.HttpClientName);
        //    _storageService = storageService;
        //}

        //private async Task GetUserName()
        //{
        //    userName = await _storageService!.GetItem("name");
        //}

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public void GotoLoginPage()
        {
            NavigationManager.NavigateTo(RoutesEnumerator.Login.GetDescription());
        }

        public void GotoIndexPage()
        {
            NavigationManager.NavigateTo(RoutesEnumerator.Index.GetDescription());
        }

        public Task<ResponseFactory<LoginResponse>> Logout(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        //public async Task<ResponseFactory<LoginResponse>> Logout(LoginRequest request)
        //{
        //    try
        //    {
        //        var result = await _httpClient.PostAsJsonAsync("Login/Logout", request);

        //        if (result == null)
        //            return null!;

        //        return await result.Content.ReadFromJsonAsync<ResponseFactory<LoginResponse>>() ??
        //                      new ResponseFactory<LoginResponse>();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return null!;
        //    }
        //}
    }
}
