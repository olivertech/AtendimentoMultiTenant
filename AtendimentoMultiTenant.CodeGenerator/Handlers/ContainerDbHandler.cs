using AtendimentoMultiTenant.Shared.ManagementArea.Requests;
using AtendimentoMultiTenant.Shared.ManagementArea.Responses;
using AtendimentoMultiTenant.Web.ManagementArea.Interfaces;
using AtendimentoMultiTenant.Web.ManagementArea.Handlers.Base;
using AtendimentoMultiTenant.Web.CommonArea.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.ContainerDb.List
{
	public class ContainerDbHandler : HandlerBase, IHandler<ContainerDbRequest, ContainerDbPagedRequest, ContainerDbResponse>, IContainerDbHandler
	{
		public ContainerDbHandler(IHttpClientFactory httpClientFactory, IStorageService storageService)
			: base(httpClientFactory, storageService)
		{}

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

		public Task<IEnumerable<ContainerDbResponse>?> GetList(Expression<Func<ContainerDbRequest, bool>> predicate)
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
