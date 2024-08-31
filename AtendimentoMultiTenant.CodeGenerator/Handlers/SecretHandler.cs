using AtendimentoMultiTenant.Shared.ManagementArea.Requests;
using AtendimentoMultiTenant.Shared.ManagementArea.Responses;
using AtendimentoMultiTenant.Web.ManagementArea.Interfaces;
using AtendimentoMultiTenant.Web.ManagementArea.Handlers.Base;
using AtendimentoMultiTenant.Web.CommonArea.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Secret.List
{
	public class SecretHandler : HandlerBase, IHandler<SecretRequest, SecretPagedRequest, SecretResponse>, ISecretHandler
	{
		public SecretHandler(IHttpClientFactory httpClientFactory, IStorageService storageService)
			: base(httpClientFactory, storageService)
		{}

		public async Task<ResponseFactory<IEnumerable<SecretResponse>>> GetAll()
		{
			ResponseFactory<IEnumerable<SecretResponse>?>? result = new()!;

			try
			{
				var requestMessage = new HttpRequestMessage(HttpMethod.Get, "Api/Secret/GetAll");

				requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
				requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.SendAsync(requestMessage);

				if (response.IsSuccessStatusCode)
				{
					result = JsonConvert.DeserializeObject<ResponseFactory<IEnumerable<SecretResponse>?>?>(response.Content.ReadAsStringAsync().Result);
				}
			}
			catch (Exception)
			{
				return new();
			}

			return result!;
		}

		public Task<ResponsePagedFactory<IEnumerable<SecretResponse>>> GetAll(SecretPagedRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<SecretResponse>?> GetList(Expression<Func<SecretRequest, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<SecretResponse>> GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<int> GetCount()
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<IEnumerable<SecretResponse>>> GetListByName(string name)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<SecretResponse>> Insert(SecretRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<SecretResponse>> Update(SecretRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<SecretResponse>> Delete(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
