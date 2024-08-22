namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Menu.List
{
	public class MenuHandler : HandlerBase, IHandler<MenuRequest, MenuPagedRequest, MenuResponse>, IMenuHandler
	{
		public MenuHandler(IHttpClientFactory httpClientFactory, IStorageService storageService)
			: base(httpClientFactory, storageService)
		{}

		public async Task<ResponseFactory<IEnumerable<MenuResponse>>> GetAll()
		{
			ResponseFactory<IEnumerable<MenuResponse>?>? result = new()!;

			try
			{
				var requestMessage = new HttpRequestMessage(HttpMethod.Get, "Api/Menu/GetAll");

				requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
				requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.SendAsync(requestMessage);

				if (response.IsSuccessStatusCode)
				{
					result = JsonConvert.DeserializeObject<ResponseFactory<IEnumerable<MenuResponse>?>?>(response.Content.ReadAsStringAsync().Result);
				}
			}
			catch (Exception)
			{
				return new();
			}

			return result!;
		}

		public Task<ResponsePagedFactory<IEnumerable<MenuResponse>>> GetAll(MenuPagedRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<MenuResponse>> GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<int> GetCount()
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<IEnumerable<MenuResponse>>> GetListByName(string name)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<MenuResponse>> Insert(MenuRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<MenuResponse>> Update(MenuRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<MenuResponse>> Delete(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
