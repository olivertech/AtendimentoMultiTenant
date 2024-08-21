using AtendimentoMultiTenant.Shared.ManagementArea.Requests;
using AtendimentoMultiTenant.Shared.ManagementArea.Responses;
using AtendimentoMultiTenant.Web.ManagementArea.Interfaces;

namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Menu.List
{
	public interface IMenuHandler : IHandler<MenuRequest, MenuPagedRequest, MenuResponse>
	{}
}
