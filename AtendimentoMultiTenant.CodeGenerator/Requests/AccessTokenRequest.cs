using AtendimentoMultiTenant.Shared.ManagementArea.Interfaces;
using AtendimentoMultiTenant.Shared.ManagementArea.Requests.Base;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AtendimentoMultiTenant.Shared.ManagementArea.Requests
{
	public class AccessTokenRequest : RequestBase, IRequest
	{
		[JsonPropertyName("createdat")]
		[JsonProperty(PropertyName = "createdat")]
		public DateOnly? CreatedAt { get; set; }

		[JsonPropertyName("expiringat")]
		[JsonProperty(PropertyName = "expiringat")]
		public DateOnly? ExpiringAt { get; set; }

		[JsonPropertyName("isactive")]
		[JsonProperty(PropertyName = "isactive")]
		public Boolean? IsActive { get; set; }

		[JsonPropertyName("timedat")]
		[JsonProperty(PropertyName = "timedat")]
		public TimeOnly? TimedAt { get; set; }

		[JsonPropertyName("token")]
		[JsonProperty(PropertyName = "token")]
		public String? Token { get; set; }

	}
}
