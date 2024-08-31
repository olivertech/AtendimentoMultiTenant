using AtendimentoMultiTenant.Shared.ManagementArea.Interfaces;
using AtendimentoMultiTenant.Shared.ManagementArea.Requests.Base;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AtendimentoMultiTenant.Shared.ManagementArea.Requests
{
	public class SecretRequest : RequestBase, IRequest
	{
		[JsonPropertyName("isactive")]
		[JsonProperty(PropertyName = "isactive")]
		public Boolean? IsActive { get; set; }

		[JsonPropertyName("secretkey")]
		[JsonProperty(PropertyName = "secretkey")]
		public String? SecretKey { get; set; }

		[JsonPropertyName("tenantid")]
		[JsonProperty(PropertyName = "tenantid")]
		public Guid? TenantId { get; set; }

	}
}
