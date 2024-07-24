
namespace AtendimentoMultiTenant.Web.HttpClientHandlers
{
    public class LoginHttpClientHandler : HttpClientHandlerBase, ILoginHttpClientHandler
    {
        /// <summary>
        /// TODO: PESQUISAR SOBRE RETRY PATTERN / BIBLIOTECA POLLY
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public LoginHttpClientHandler(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
        }

        public async Task<ResponseFactory<LoginResponse>> Auth(LoginRequest request)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync("Login/Auth", request);

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
    }
}
