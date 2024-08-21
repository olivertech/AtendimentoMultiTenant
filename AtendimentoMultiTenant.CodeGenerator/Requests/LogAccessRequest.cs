using AtendimentoMultiTenant.Shared.ManagementArea.Interfaces;
using AtendimentoMultiTenant.Shared.ManagementArea.Requests.Base;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AtendimentoMultiTenant.Shared.ManagementArea.Requests
{
	public class LogAccessRequest : RequestBase, IRequest
	{
		[JsonPropertyName("createdat")]
		[JsonProperty(PropertyName = "createdat")]
		public DateOnly? CreatedAt { get; set; }

		[JsonPropertyName("isactive")]
		[JsonProperty(PropertyName = "isactive")]
		public Boolean? IsActive { get; set; }

		[JsonPropertyName("timedat")]
		[JsonProperty(PropertyName = "timedat")]
		public TimeOnly? TimedAt { get; set; }

		[JsonPropertyName("userid")]
		[JsonProperty(PropertyName = "userid")]
		public Guid? UserId { get; set; }

	}
}
