using AtendimentoMultiTenant.Shared.ManagementArea.Requests;
using AtendimentoMultiTenant.Shared.ManagementArea.Responses;
using AtendimentoMultiTenant.Web.ManagementArea.Interfaces;

namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Tenant.List
{
	public interface ITenantHandler : IHandler<TenantRequest, TenantPagedRequest, TenantResponse>
	{}
}
