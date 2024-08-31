namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Role.List
{
	public class RoleHandler : HandlerBase, IHandler<RoleRequest, RolePagedRequest, RoleResponse>, IRoleHandler
	{
		public RoleHandler(IHttpClientFactory httpClientFactory, IStorageService storageService)
			: base(httpClientFactory, storageService)
		{}

		public async Task<ResponseFactory<IEnumerable<RoleResponse>>> GetAll()
		{
			ResponseFactory<IEnumerable<RoleResponse>?>? result = new()!;

			try
			{
				var requestMessage = new HttpRequestMessage(HttpMethod.Get, "Api/Role/GetAll");

				requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
				requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.SendAsync(requestMessage);

				if (response.IsSuccessStatusCode)
				{
					result = JsonConvert.DeserializeObject<ResponseFactory<IEnumerable<RoleResponse>?>?>(response.Content.ReadAsStringAsync().Result);
				}
			}
			catch (Exception)
			{
				return new();
			}

			return result!;
		}

		public Task<ResponsePagedFactory<IEnumerable<RoleResponse>>> GetAll(RolePagedRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<RoleResponse>> GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<int> GetCount()
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<IEnumerable<RoleResponse>>> GetListByName(string name)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<RoleResponse>> Insert(RoleRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<RoleResponse>> Update(RoleRequest request)
		{
			throw new NotImplementedException();
		}

		public async Task<ResponseFactory<RoleResponse>> Delete(Guid id)
		{
			ResponseFactory<RoleResponse>? result = new()!;

			try
			{
				var requestMessage = new HttpRequestMessage(HttpMethod.Delete, $"Api/Role/Delete/{id}");
				requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
				requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.SendAsync(requestMessage);

				if (response.IsSuccessStatusCode)
				{
					result = JsonConvert.DeserializeObject<ResponseFactory<RoleResponse>?>(response.Content.ReadAsStringAsync().Result);
				}
			}
			catch (Exception)
			{
				return new();
			}

			return result!;
		}

		public Task<IEnumerable<RoleResponse>?> GetList(Expression<Func<RoleRequest, bool>> predicate)
		{
			throw new NotImplementedException();
		}
	}
}
