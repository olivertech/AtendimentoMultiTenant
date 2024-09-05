using AtendimentoMultiTenant.Shared.ManagementArea.Requests;
using AtendimentoMultiTenant.Shared.ManagementArea.Responses;
using AtendimentoMultiTenant.Web.ManagementArea.Interfaces;
using AtendimentoMultiTenant.Web.ManagementArea.Handlers.Base;
using AtendimentoMultiTenant.Web.CommonArea.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Linq.Expressions;

namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Port.List
{
	public class PortHandler : HandlerBase, IHandler<PortRequest, PortPagedRequest, PortResponse>, IPortHandler
	{
		public PortHandler(IHttpClientFactory httpClientFactory, IStorageService storageService)
			: base(httpClientFactory, storageService)
		{}

		public async Task<ResponseFactory<IEnumerable<PortResponse>>> GetAll()
		{
			ResponseFactory<IEnumerable<PortResponse>?>? result = new()!;

			try
			{
				var requestMessage = new HttpRequestMessage(HttpMethod.Get, "Api/Port/GetAll");

				requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
				requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.SendAsync(requestMessage);

				if (response.IsSuccessStatusCode)
				{
					result = JsonConvert.DeserializeObject<ResponseFactory<IEnumerable<PortResponse>?>?>(response.Content.ReadAsStringAsync().Result);
				}
			}
			catch (Exception)
			{
				return new();
			}

			return result!;
		}

		public Task<ResponsePagedFactory<IEnumerable<PortResponse>>> GetAll(PortPagedRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<PortResponse>?> GetList(Expression<Func<PortRequest, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<PortResponse>> GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<int> GetCount()
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<IEnumerable<PortResponse>>> GetListByName(string name)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<PortResponse>> Insert(PortRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<PortResponse>> Update(PortRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<PortResponse>> Delete(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
