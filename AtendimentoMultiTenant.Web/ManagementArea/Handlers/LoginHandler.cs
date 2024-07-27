namespace AtendimentoMultiTenant.Web.ManagementArea.Handlers
{
    public class LoginHandler : ILoginHandler
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// TODO: PESQUISAR SOBRE RETRY PATTERN / BIBLIOTECA POLLY
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public LoginHandler(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(SharedConfigurations.HttpClientName);
        }

        public async Task<ResponseFactory<LoginResponse>> Auth(LoginRequest request)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Api/Login/Auth", request);
                var returnValue = await response.Content.ReadFromJsonAsync<ResponseFactory<LoginResponse>>();

                if (!returnValue!.IsSuccess)
                    return null!;

                return returnValue ?? new ResponseFactory<LoginResponse>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null!;
            }
        }

        public async Task<ResponseFactory<LoginResponse>> Logout(LoginRequest request)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync("Login/Logout", request);

                if (result == null)
                    return null!;

                return await result.Content.ReadFromJsonAsync<ResponseFactory<LoginResponse>>() ??
                              new ResponseFactory<LoginResponse>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null!;
            }
        }

        //private async Task WriteSingleSignOnData(string key)
        //{
        //    await JsRuntime.InvokeVoidAsync("WriteCookie", "cookieName", "cookieValue", 7);
        //}

        //private async Task ReadSingleSignOnData()
        //{
        //    var cookieValue = await JsRuntime.InvokeAsync<string>("ReadCookie", "cookieName");
        //    // Use o valor do cookie conforme necessário
        //}
    }
}
