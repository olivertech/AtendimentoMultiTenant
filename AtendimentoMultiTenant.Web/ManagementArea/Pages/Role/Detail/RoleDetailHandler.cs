using System.Linq.Expressions;

namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Role.Detail
{
    public class RoleDetailHandler : HandlerBase, IHandler<RoleRequest, RolePagedRequest, RoleResponse>, IRoleDetailHandler
    {
        public RoleDetailHandler(IHttpClientFactory httpClientFactory,
                                 IStorageService storageService)
            : base(httpClientFactory, storageService)
        {
        }

        public Task<ResponseFactory<RoleResponse>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseFactory<IEnumerable<RoleResponse>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponsePagedFactory<IEnumerable<RoleResponse>>> GetAll(RolePagedRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseFactory<RoleResponse>> GetById(Guid id)
        {
            ResponseFactory<RoleResponse>? result = null!;

            try
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"Api/Role/GetById/{id}");

                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.SendAsync(requestMessage);

                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<ResponseFactory<RoleResponse>?>(response.Content.ReadAsStringAsync().Result);
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

        public Task<IEnumerable<RoleResponse>?> GetList(Expression<Func<RoleRequest, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseFactory<IEnumerable<RoleResponse>>> GetListByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseFactory<RoleResponse>> Insert(RoleRequest request)
        {
            ResponseFactory<RoleResponse>? result = null!;

            try
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, "Api/Role/Insert");
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
                requestMessage.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

                var response = await _httpClient.SendAsync(requestMessage);

                if (!response!.IsSuccessStatusCode)
                    return null!;

                result = JsonConvert.DeserializeObject<ResponseFactory<RoleResponse>?>(response.Content.ReadAsStringAsync().Result);
            }
            catch (Exception)
            {
                return new();
            }

            return result!;
        }

        public async Task<ResponseFactory<RoleResponse>> Update(RoleRequest request)
        {
            ResponseFactory<RoleResponse>? result = null!;

            try
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Put, "Api/Role/Update");
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
                requestMessage.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

                var response = await _httpClient.SendAsync(requestMessage);

                if (!response!.IsSuccessStatusCode)
                    return null!;

                result = JsonConvert.DeserializeObject<ResponseFactory<RoleResponse>?>(response.Content.ReadAsStringAsync().Result);
            }
            catch (Exception)
            {
                return new();
            }

            return result!;
        }
    }
}
