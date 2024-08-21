using AtendimentoMultiTenant.Shared.ManagementArea.Requests;
using AtendimentoMultiTenant.Shared.ManagementArea.Responses;
using AtendimentoMultiTenant.Web.ManagementArea.Interfaces;

namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.LogAccess.List
{
	public interface ILogAccessHandler : IHandler<LogAccessRequest, LogAccessPagedRequest, LogAccessResponse>
	{}
}
