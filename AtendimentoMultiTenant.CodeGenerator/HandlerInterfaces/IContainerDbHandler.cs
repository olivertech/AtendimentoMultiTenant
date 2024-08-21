using AtendimentoMultiTenant.Shared.ManagementArea.Requests;
using AtendimentoMultiTenant.Shared.ManagementArea.Responses;
using AtendimentoMultiTenant.Web.ManagementArea.Interfaces;

namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.ContainerDb.List
{
	public interface IContainerDbHandler : IHandler<ContainerDbRequest, ContainerDbPagedRequest, ContainerDbResponse>
	{}
}
