﻿namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Menu.Detail
{
    public class MenuDetailHandler : HandlerBase, IHandler<MenuRequest, MenuPagedRequest, MenuResponse>, IMenuDetailHandler
    {
        public MenuDetailHandler(IHttpClientFactory httpClientFactory, 
                                 IStorageService storageService) 
            : base(httpClientFactory, storageService)
        {
        }

        public Task<ResponseFactory<MenuResponse>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseFactory<IEnumerable<MenuResponse>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponsePagedFactory<IEnumerable<MenuResponse>>> GetAll(MenuPagedRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseFactory<MenuResponse>> GetById(Guid id)
        {
            ResponseFactory<MenuResponse>? result = null!;

            try
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"Api/Menu/GetById/{id}");

                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.SendAsync(requestMessage);

                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<ResponseFactory<MenuResponse>?>(response.Content.ReadAsStringAsync().Result);
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

        public Task<ResponseFactory<IEnumerable<MenuResponse>>> GetListByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseFactory<MenuResponse>> Insert(MenuRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseFactory<MenuResponse>> Update(MenuRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
