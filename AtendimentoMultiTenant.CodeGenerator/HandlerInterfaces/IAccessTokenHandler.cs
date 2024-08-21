using AtendimentoMultiTenant.Shared.ManagementArea.Requests;
using AtendimentoMultiTenant.Shared.ManagementArea.Responses;
using AtendimentoMultiTenant.Web.ManagementArea.Interfaces;

namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.AccessToken.List
{
	public interface IAccessTokenHandler : IHandler<AccessTokenRequest, AccessTokenPagedRequest, AccessTokenResponse>
	{}
}
