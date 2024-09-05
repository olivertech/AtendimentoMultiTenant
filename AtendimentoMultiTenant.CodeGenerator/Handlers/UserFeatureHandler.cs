using AtendimentoMultiTenant.Shared.ManagementArea.Requests;
using AtendimentoMultiTenant.Shared.ManagementArea.Responses;
using AtendimentoMultiTenant.Web.ManagementArea.Interfaces;
using AtendimentoMultiTenant.Web.ManagementArea.Handlers.Base;
using AtendimentoMultiTenant.Web.CommonArea.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Linq.Expressions;

namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.UserFeature.List
{
	public class UserFeatureHandler : HandlerBase, IHandler<UserFeatureRequest, UserFeaturePagedRequest, UserFeatureResponse>, IUserFeatureHandler
	{
		public UserFeatureHandler(IHttpClientFactory httpClientFactory, IStorageService storageService)
			: base(httpClientFactory, storageService)
		{}

		public async Task<ResponseFactory<IEnumerable<UserFeatureResponse>>> GetAll()
		{
			ResponseFactory<IEnumerable<UserFeatureResponse>?>? result = new()!;

			try
			{
				var requestMessage = new HttpRequestMessage(HttpMethod.Get, "Api/UserFeature/GetAll");

				requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
				requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.SendAsync(requestMessage);

				if (response.IsSuccessStatusCode)
				{
					result = JsonConvert.DeserializeObject<ResponseFactory<IEnumerable<UserFeatureResponse>?>?>(response.Content.ReadAsStringAsync().Result);
				}
			}
			catch (Exception)
			{
				return new();
			}

			return result!;
		}

		public Task<ResponsePagedFactory<IEnumerable<UserFeatureResponse>>> GetAll(UserFeaturePagedRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<UserFeatureResponse>?> GetList(Expression<Func<UserFeatureRequest, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<UserFeatureResponse>> GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<int> GetCount()
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<IEnumerable<UserFeatureResponse>>> GetListByName(string name)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<UserFeatureResponse>> Insert(UserFeatureRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<UserFeatureResponse>> Update(UserFeatureRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<UserFeatureResponse>> Delete(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
