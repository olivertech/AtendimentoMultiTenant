namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.ContainerDb.Detail
{
    public class ContainerDbDetailHandler : HandlerBase, IHandler<ContainerDbRequest, ContainerDbPagedRequest, ContainerDbResponse>, IContainerDbDetailHandler
    {
        public ContainerDbDetailHandler(IHttpClientFactory httpClientFactory, 
                                        IStorageService storageService)
            : base(httpClientFactory, storageService)
        {
        }

        public Task<ResponseFactory<ContainerDbResponse>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseFactory<IEnumerable<ContainerDbResponse>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponsePagedFactory<IEnumerable<ContainerDbResponse>>> GetAll(ContainerDbPagedRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseFactory<ContainerDbResponse>> GetById(Guid id)
        {
            ResponseFactory<ContainerDbResponse>? result = null!;

            try
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"Api/ContainerDb/GetById/{id}");

                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.SendAsync(requestMessage);

                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<ResponseFactory<ContainerDbResponse>?>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception)
            {
                return new();
            }

            return result!;
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
    }
}
