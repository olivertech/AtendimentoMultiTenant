using AtendimentoMultiTenant.Shared.ManagementArea.Requests;
using AtendimentoMultiTenant.Shared.ManagementArea.Responses;
using AtendimentoMultiTenant.Web.ManagementArea.Interfaces;
using AtendimentoMultiTenant.Web.ManagementArea.Handlers.Base;
using AtendimentoMultiTenant.Web.CommonArea.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Tenant.List
{
	public class TenantHandler : HandlerBase, IHandler<TenantRequest, TenantPagedRequest, TenantResponse>, ITenantHandler
	{
		public TenantHandler(IHttpClientFactory httpClientFactory, IStorageService storageService)
			: base(httpClientFactory, storageService)
		{}

		public async Task<ResponseFactory<IEnumerable<TenantResponse>>> GetAll()
		{
			ResponseFactory<IEnumerable<TenantResponse>?>? result = new()!;

			try
			{
				var requestMessage = new HttpRequestMessage(HttpMethod.Get, "Api/Tenant/GetAll");

				requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
				requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.SendAsync(requestMessage);

				if (response.IsSuccessStatusCode)
				{
					result = JsonConvert.DeserializeObject<ResponseFactory<IEnumerable<TenantResponse>?>?>(response.Content.ReadAsStringAsync().Result);
				}
			}
			catch (Exception)
			{
				return new();
			}

			return result!;
		}

		public Task<ResponsePagedFactory<IEnumerable<TenantResponse>>> GetAll(TenantPagedRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<TenantResponse>?> GetList(Expression<Func<TenantRequest, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<TenantResponse>> GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<int> GetCount()
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<IEnumerable<TenantResponse>>> GetListByName(string name)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<TenantResponse>> Insert(TenantRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<TenantResponse>> Update(TenantRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<TenantResponse>> Delete(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
