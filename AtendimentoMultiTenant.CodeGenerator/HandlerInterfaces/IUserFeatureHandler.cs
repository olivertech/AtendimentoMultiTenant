using AtendimentoMultiTenant.Shared.ManagementArea.Requests;
using AtendimentoMultiTenant.Shared.ManagementArea.Responses;
using AtendimentoMultiTenant.Web.ManagementArea.Interfaces;

namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.UserFeature.List
{
	public interface IUserFeatureHandler : IHandler<UserFeatureRequest, UserFeaturePagedRequest, UserFeatureResponse>
	{}
}
