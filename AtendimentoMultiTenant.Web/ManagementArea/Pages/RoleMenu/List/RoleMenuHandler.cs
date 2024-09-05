namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.RoleMenu.List
{
	public class RoleMenuHandler : HandlerBase, IRoleMenuHandler
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

		public async Task<ResponseFactory<IEnumerable<RoleMenuResponse>>> GetRoleMenuList(string roleId)
		{
			ResponseFactory<IEnumerable<RoleMenuResponse>>? result = null!;

			try
			{
				var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"Api/RoleMenu/GetAllByRoleId/{roleId}");

				requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
				requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.SendAsync(requestMessage);

				if (response.IsSuccessStatusCode)
				{
					result = JsonConvert.DeserializeObject<ResponseFactory<IEnumerable<RoleMenuResponse>>>(response.Content.ReadAsStringAsync().Result);
				}
			}
			catch (Exception)
			{
				return new();
			}

			return result ?? new();
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

		public Task<IEnumerable<RoleMenuResponse>?> GetList(Expression<Func<RoleMenuRequest, bool>> predicate)
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
