using AtendimentoMultiTenant.Shared.ManagementArea.Requests;
using AtendimentoMultiTenant.Shared.ManagementArea.Responses;
using AtendimentoMultiTenant.Web.ManagementArea.Handlers.Base;
using AtendimentoMultiTenant.Web.ManagementArea.Interfaces;

namespace AtendimentoMultiTenant.Web.ManagementArea.Handlers
{
    public class ContainerDbHandler : HandlerBase, IHandler<ContainerDbRequest, ContainerDbResponse>, IContainerDbHandler
    {
        /// <summary>
        /// TODO: PESQUISAR SOBRE RETRY PATTERN / BIBLIOTECA POLLY
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public ContainerDbHandler(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
        }

        public async Task<ResponsePagedFactory<IEnumerable<ContainerDbResponse>>> GetAll(ContainerDbRequest request)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync("Configuration/GetAll", request);

                if (result == null)
                    return null!;

                return await result.Content.ReadFromJsonAsync<ResponsePagedFactory<IEnumerable<ContainerDbResponse>>>() ??
                             new ResponsePagedFactory<IEnumerable<ContainerDbResponse>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null!;
            }
        }

        public async Task<ResponseFactory<ContainerDbResponse>> GetById(Guid id)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<ResponseFactory<ContainerDbResponse>>($"Configuration/GetById/{id}");

                if (result == null)
                    return null!;

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null!;
            }
        }

        public async Task<int> GetCount()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<int>($"Configuration/GetCount");

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public async Task<ResponseFactory<IEnumerable<ContainerDbResponse>>> GetListByName(string name)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<ResponseFactory<IEnumerable<ContainerDbResponse>>>($"Configuration/GetListByName/{name}");

                if (result == null)
                    return null!;

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null!;
            }
        }

        public async Task<ResponseFactory<ContainerDbResponse>> Insert(ContainerDbRequest request)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync("Configuration/Insert", request);

                if (result == null)
                    return null!;

                return await result.Content.ReadFromJsonAsync<ResponseFactory<ContainerDbResponse>>() ??
                             new ResponseFactory<ContainerDbResponse>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null!;
            }
        }

        public async Task<ResponseFactory<ContainerDbResponse>> Update(ContainerDbRequest request)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync($"Configuration/Update/{request.Id}", request);

                if (result == null)
                    return null!;

                return await result.Content.ReadFromJsonAsync<ResponseFactory<ContainerDbResponse>>() ??
                             new ResponseFactory<ContainerDbResponse>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null!;
            }
        }

        public async Task<ResponseFactory<ContainerDbResponse>> Delete(Guid id)
        {
            try
            {
                var result = await _httpClient.DeleteFromJsonAsync<ResponseFactory<ContainerDbResponse>>($"Configuration/Delete/{id}");

                if (result == null)
                    return null!;

                return result ?? new ResponseFactory<ContainerDbResponse>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null!;
            }
        }
    }
}
