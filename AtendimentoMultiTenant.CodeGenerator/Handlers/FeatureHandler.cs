using AtendimentoMultiTenant.Shared.ManagementArea.Requests;
using AtendimentoMultiTenant.Shared.ManagementArea.Responses;
using AtendimentoMultiTenant.Web.ManagementArea.Interfaces;
using AtendimentoMultiTenant.Web.ManagementArea.Handlers.Base;
using AtendimentoMultiTenant.Web.CommonArea.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Linq.Expressions;

namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Feature.List
{
	public class FeatureHandler : HandlerBase, IHandler<FeatureRequest, FeaturePagedRequest, FeatureResponse>, IFeatureHandler
	{
		public FeatureHandler(IHttpClientFactory httpClientFactory, IStorageService storageService)
			: base(httpClientFactory, storageService)
		{}

		public async Task<ResponseFactory<IEnumerable<FeatureResponse>>> GetAll()
		{
			ResponseFactory<IEnumerable<FeatureResponse>?>? result = new()!;

			try
			{
				var requestMessage = new HttpRequestMessage(HttpMethod.Get, "Api/Feature/GetAll");

				requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
				requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.SendAsync(requestMessage);

				if (response.IsSuccessStatusCode)
				{
					result = JsonConvert.DeserializeObject<ResponseFactory<IEnumerable<FeatureResponse>?>?>(response.Content.ReadAsStringAsync().Result);
				}
			}
			catch (Exception)
			{
				return new();
			}

			return result!;
		}

		public Task<ResponsePagedFactory<IEnumerable<FeatureResponse>>> GetAll(FeaturePagedRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<FeatureResponse>?> GetList(Expression<Func<FeatureRequest, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<FeatureResponse>> GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<int> GetCount()
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<IEnumerable<FeatureResponse>>> GetListByName(string name)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<FeatureResponse>> Insert(FeatureRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<FeatureResponse>> Update(FeatureRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseFactory<FeatureResponse>> Delete(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
