using AtendimentoMultiTenant.Shared.ManagementArea.Requests;
using AtendimentoMultiTenant.Shared.ManagementArea.Responses;
using AtendimentoMultiTenant.Web.ManagementArea.Interfaces;
using AtendimentoMultiTenant.Web.ManagementArea.Handlers.Base;
using AtendimentoMultiTenant.Web.CommonArea.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.User.List
{
	public class UserHandler : HandlerBase, IHandler<UserRequest, UserPagedRequest, UserResponse>, IUserHandler
	{
		public UserHandler(IHttpClientFactory httpClientFactory, IStorageService storageService)
			: base(httpClientFactory, storageService)
		{}

		public async Task<ResponseFactory<IEnumerable<UserResponse>>> GetAll()
		{
			ResponseFactory<IEnumerable<UserResponse>?>? result = new()!;

			try
			{
				var requestMessage = new HttpRequestMessage(HttpMethod.Get, "Api/User/GetAll");

				requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
				requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.SendAsync(requestMessage);

				if (response.IsSuccessStatusCode)
				{
					result = JsonConvert.DeserializeObject<ResponseFactory<IEnumerable<UserResponse>?>?>(response.Content.ReadAsStringAsync().Result);
				}
			}
			catch (Exception)
			{
				return new();
			}

			return result!;
		}

		public Task<ResponsePagedFactory<IEnumerable<UserResponse>>> GetAll(UserPagedRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<UserResponse>?> GetList(Expression<Func<UserRequest, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<UserResponse>> GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<int> GetCount()
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<IEnumerable<UserResponse>>> GetListByName(string name)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<UserResponse>> Insert(UserRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<UserResponse>> Update(UserRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<UserResponse>> Delete(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
