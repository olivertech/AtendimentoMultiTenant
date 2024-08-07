
namespace AtendimentoMultiTenant.Web.ManagementArea.Areas.Pages.LogAccess
{
    public class LogAccessHandler : HandlerBase, IHandler<LogAccessRequest, LogAccessResponse>, ILogAccessHandler
    {
        public LogAccessHandler(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
        }

        public async Task<ResponsePagedFactory<IEnumerable<LogAccessResponse>>> GetAll(LogAccessRequest request)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<ResponsePagedFactory<IEnumerable<LogAccessResponse>>>("LogAccess/GetAll");

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
