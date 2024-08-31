using AtendimentoMultiTenant.Shared.ManagementArea.Interfaces;
using Newtonsoft.Json;

namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses
{
	public class SecretResponse : IResponse
	{
		[JsonProperty(PropertyName = "id")]
		public Guid? Id { get; set; }

		[JsonProperty(PropertyName = "isactive")]
		public Boolean? IsActive { get; set; }

		[JsonProperty(PropertyName = "secretkey")]
		public String? SecretKey { get; set; }

		[JsonProperty(PropertyName = "tenantid")]
		public Guid? TenantId { get; set; }

	}
}
