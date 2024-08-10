namespace AtendimentoMultiTenant.Web.ManagementArea.Areas.Pages.Login
{
    public class LoginHandler : ILoginHandler
    {
        #region Properties and Variables
        
        private readonly HttpClient _httpClient;
        private readonly IStorageService _storageService;

        #endregion

        #region Constructor

        /// <summary>
        /// TODO: PESQUISAR SOBRE RETRY PATTERN / BIBLIOTECA POLLY
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public LoginHandler(IHttpClientFactory httpClientFactory, IStorageService storageService)
        {
            _httpClient = httpClientFactory.CreateClient(SharedConfigurations.HttpClientName);
            _storageService = storageService;
        }

        #endregion

        #region Methods

        public async Task<ResponseFactory<LoginResponse>> Auth(LoginRequest request)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Api/Login/Auth", request);
                var returnValue = await response.Content.ReadFromJsonAsync<ResponseFactory<LoginResponse>>();

                if (!returnValue!.IsSuccess)
                    return null!;

                // Salva os valores retornados do login em session
                List<Item> listItems = new()
                {
                    new Item { Key = "token", Data = returnValue.Result!.AccessToken!.Token! },
                    new Item { Key = "name", Data = returnValue.Result!.Name },
                    new Item { Key = "email", Data = returnValue.Result!.Email },
                    new Item { Key = "secret", Data = returnValue.Result!.Secret },
                };

                await _storageService.SetListItem(listItems);

                return returnValue ?? new ResponseFactory<LoginResponse>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null!;
            }
        }

        #endregion
    }
}
