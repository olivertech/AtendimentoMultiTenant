using AtendimentoMultiTenant.Shared.ManagementArea.Requests;
using AtendimentoMultiTenant.Shared.ManagementArea.Responses;
using AtendimentoMultiTenant.Web.ManagementArea.Interfaces;
using AtendimentoMultiTenant.Web.ManagementArea.Handlers.Base;
using AtendimentoMultiTenant.Web.CommonArea.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.AccessToken.List
{
	public class AccessTokenHandler : HandlerBase, IHandler<AccessTokenRequest, AccessTokenPagedRequest, AccessTokenResponse>, IAccessTokenHandler
	{
		public AccessTokenHandler(IHttpClientFactory httpClientFactory, IStorageService storageService)
			: base(httpClientFactory, storageService)
		{}

		public async Task<ResponseFactory<IEnumerable<AccessTokenResponse>>> GetAll()
		{
			ResponseFactory<IEnumerable<AccessTokenResponse>?>? result = new()!;

			try
			{
				var requestMessage = new HttpRequestMessage(HttpMethod.Get, "Api/AccessToken/GetAll");

				requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
				requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.SendAsync(requestMessage);

				if (response.IsSuccessStatusCode)
				{
					result = JsonConvert.DeserializeObject<ResponseFactory<IEnumerable<AccessTokenResponse>?>?>(response.Content.ReadAsStringAsync().Result);
				}
			}
			catch (Exception)
			{
				return new();
			}

			return result!;
		}

		public Task<ResponsePagedFactory<IEnumerable<AccessTokenResponse>>> GetAll(AccessTokenPagedRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<AccessTokenResponse>?> GetList(Expression<Func<AccessTokenRequest, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<AccessTokenResponse>> GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<int> GetCount()
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<IEnumerable<AccessTokenResponse>>> GetListByName(string name)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<AccessTokenResponse>> Insert(AccessTokenRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<AccessTokenResponse>> Update(AccessTokenRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<AccessTokenResponse>> Delete(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
