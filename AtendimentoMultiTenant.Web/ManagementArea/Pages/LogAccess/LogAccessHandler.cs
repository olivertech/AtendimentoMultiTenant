namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.LogAccess
{
    public class LogAccessHandler : HandlerBase, IHandler<LogAccessRequest, LogAccessPagedRequest, LogAccessResponse>, ILogAccessHandler
    {
        public LogAccessHandler(IHttpClientFactory httpClientFactory, IStorageService storageService)
            : base(httpClientFactory, storageService)
        {
        }

        public async Task<ResponseFactory<IEnumerable<LogAccessResponse>>> GetAll()
        {
            ResponseFactory<IEnumerable<LogAccessResponse>?>? result = new()!;

            try
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, "Api/LogAccess/GetAll");

                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.SendAsync(requestMessage);

                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<ResponseFactory<IEnumerable<LogAccessResponse>?>?>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception)
            {
                return new();
            }

            return result!;
        }

        public Task<ResponsePagedFactory<IEnumerable<LogAccessResponse>>> GetAll(LogAccessPagedRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseFactory<LogAccessResponse>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCount()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseFactory<IEnumerable<LogAccessResponse>>> GetListByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseFactory<LogAccessResponse>> Insert(LogAccessRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseFactory<LogAccessResponse>> Update(LogAccessRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseFactory<LogAccessResponse>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
