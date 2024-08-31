namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Feature.List
{
	public interface IFeatureHandler : IHandler<FeatureRequest, FeaturePagedRequest, FeatureResponse>
	{
		Task<ResponseFactory<FeatureResponse>> Delete(Guid id, string type);
	}
}
