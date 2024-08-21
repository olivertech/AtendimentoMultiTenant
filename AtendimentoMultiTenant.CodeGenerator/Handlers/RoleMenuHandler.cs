using AtendimentoMultiTenant.Shared.ManagementArea.Requests;
using AtendimentoMultiTenant.Shared.ManagementArea.Responses;
using AtendimentoMultiTenant.Web.ManagementArea.Interfaces;
using AtendimentoMultiTenant.Web.ManagementArea.Handlers.Base;
using AtendimentoMultiTenant.Web.CommonArea.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.RoleMenu.List
{
	public class RoleMenuHandler : HandlerBase, IHandler<RoleMenuRequest, RoleMenuPagedRequest, RoleMenuResponse>, IRoleMenuHandler
	{
		public RoleMenuHandler(IHttpClientFactory httpClientFactory, IStorageService storageService)
			: base(httpClientFactory, storageService)
		{}

		public async Task<ResponseFactory<IEnumerable<RoleMenuResponse>>> GetAll()
		{
			ResponseFactory<IEnumerable<RoleMenuResponse>?>? result = new()!;

			try
			{
				var requestMessage = new HttpRequestMessage(HttpMethod.Get, "Api/RoleMenu/GetAll");

				requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
				requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.SendAsync(requestMessage);

				if (response.IsSuccessStatusCode)
				{
					result = JsonConvert.DeserializeObject<ResponseFactory<IEnumerable<RoleMenuResponse>?>?>(response.Content.ReadAsStringAsync().Result);
				}
			}
			catch (Exception)
			{
				return new();
			}

			return result!;
		}

		public Task<ResponsePagedFactory<IEnumerable<RoleMenuResponse>>> GetAll(RoleMenuPagedRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<RoleMenuResponse>> GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<int> GetCount()
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<IEnumerable<RoleMenuResponse>>> GetListByName(string name)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<RoleMenuResponse>> Insert(RoleMenuRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<RoleMenuResponse>> Update(RoleMenuRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<RoleMenuResponse>> Delete(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
