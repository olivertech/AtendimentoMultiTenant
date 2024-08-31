using AtendimentoMultiTenant.Shared.ManagementArea.Interfaces;
using AtendimentoMultiTenant.Shared.ManagementArea.Requests.Base;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AtendimentoMultiTenant.Shared.ManagementArea.Requests
{
	public class TenantRequest : RequestBase, IRequest
	{
		[JsonPropertyName("connectionstring")]
		[JsonProperty(PropertyName = "connectionstring")]
		public String? ConnectionString { get; set; }

		[JsonPropertyName("createdat")]
		[JsonProperty(PropertyName = "createdat")]
		public DateOnly? CreatedAt { get; set; }

		[JsonPropertyName("deactivatedtimedat")]
		[JsonProperty(PropertyName = "deactivatedtimedat")]
		public TimeOnly? DeactivatedTimedAt { get; set; }

		[JsonPropertyName("deativatedat")]
		[JsonProperty(PropertyName = "deativatedat")]
		public DateOnly? DeativatedAt { get; set; }

		[JsonPropertyName("initialurl")]
		[JsonProperty(PropertyName = "initialurl")]
		public String? InitialUrl { get; set; }

		[JsonPropertyName("isactive")]
		[JsonProperty(PropertyName = "isactive")]
		public Boolean? IsActive { get; set; }

		[JsonPropertyName("name")]
		[JsonProperty(PropertyName = "name")]
		public String? Name { get; set; }

		[JsonPropertyName("timedat")]
		[JsonProperty(PropertyName = "timedat")]
		public TimeOnly? TimedAt { get; set; }

	}
}
