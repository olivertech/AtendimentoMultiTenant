namespace AtendimentoMultiTenant.Web.ManagementArea.Areas.Login
{
    public class LoginHandler : ILoginHandler
    {
        private readonly HttpClient _httpClient;
        private readonly IStorageService _storageService;

        /// <summary>
        /// TODO: PESQUISAR SOBRE RETRY PATTERN / BIBLIOTECA POLLY
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public LoginHandler(IHttpClientFactory httpClientFactory, IStorageService storageService)
        {
            _httpClient = httpClientFactory.CreateClient(SharedConfigurations.HttpClientName);
            _storageService = storageService;
        }

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
                    new Item { Key = "token", Data = returnValue.Content!.Token },
                    new Item { Key = "name", Data = returnValue.Content!.Name },
                    new Item { Key = "email", Data = returnValue.Content!.Email },
                    new Item { Key = "identifier", Data = returnValue.Content!.Identifier },
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
    }
}
