using AtendimentoMultiTenant.Shared.ManagementArea.Requests;
using AtendimentoMultiTenant.Shared.ManagementArea.Responses;
using AtendimentoMultiTenant.Web.ManagementArea.Interfaces;

namespace AtendimentoMultiTenant.Web.ManagementArea.Pages.Secret.List
{
	public interface ISecretHandler : IHandler<SecretRequest, SecretPagedRequest, SecretResponse>
	{}
}
