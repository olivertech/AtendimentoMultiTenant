using AtendimentoMultiTenant.Shared.ManagementArea.Requests;
using AtendimentoMultiTenant.Shared.ManagementArea.Responses;
using AtendimentoMultiTenant.Web.ManagementArea.Interfaces;

namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.RoleMenu.List
{
	public interface IRoleMenuHandler : IHandler<RoleMenuRequest, RoleMenuPagedRequest, RoleMenuResponse>
	{}
}
