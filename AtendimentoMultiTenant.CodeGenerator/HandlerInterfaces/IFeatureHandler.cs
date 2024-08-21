using AtendimentoMultiTenant.Shared.ManagementArea.Requests;
using AtendimentoMultiTenant.Shared.ManagementArea.Responses;
using AtendimentoMultiTenant.Web.ManagementArea.Interfaces;

namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Feature.List
{
	public interface IFeatureHandler : IHandler<FeatureRequest, FeaturePagedRequest, FeatureResponse>
	{}
}
