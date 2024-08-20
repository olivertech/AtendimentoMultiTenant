namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.ContainerDb.List
{
    public class ContainerDbHandler : HandlerBase, IHandler<ContainerDbRequest, ContainerDbPagedRequest, ContainerDbResponse>, IContainerDbHandler
    {
        /// <summary>
        /// TODO: PESQUISAR SOBRE RETRY PATTERN / BIBLIOTECA POLLY
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public ContainerDbHandler(IHttpClientFactory httpClientFactory, IStorageService storageService)
            : base(httpClientFactory, storageService)
        {
        }

        public async Task<ResponseFactory<IEnumerable<ContainerDbResponse>>> GetAll()
        {
            ResponseFactory<IEnumerable<ContainerDbResponse>?>? result = new()!;

            try
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, "Api/ContainerDb/GetAll");

                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.SendAsync(requestMessage);

                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<ResponseFactory<IEnumerable<ContainerDbResponse>?>?>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception)
            {
                return new();
            }

            return result!;
        }

        public Task<ResponsePagedFactory<IEnumerable<ContainerDbResponse>>> GetAll(ContainerDbPagedRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseFactory<ContainerDbResponse>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCount()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseFactory<IEnumerable<ContainerDbResponse>>> GetListByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseFactory<ContainerDbResponse>> Insert(ContainerDbRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseFactory<ContainerDbResponse>> Update(ContainerDbRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseFactory<ContainerDbResponse>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
