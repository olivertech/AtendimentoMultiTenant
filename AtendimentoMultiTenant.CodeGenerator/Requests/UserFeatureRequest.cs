using AtendimentoMultiTenant.Shared.ManagementArea.Interfaces;
using AtendimentoMultiTenant.Shared.ManagementArea.Requests.Base;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AtendimentoMultiTenant.Shared.ManagementArea.Requests
{
	public class UserFeatureRequest : RequestBase, IRequest
	{
		[JsonPropertyName("featureid")]
		[JsonProperty(PropertyName = "featureid")]
		public Guid? FeatureId { get; set; }

		[JsonPropertyName("isactive")]
		[JsonProperty(PropertyName = "isactive")]
		public Boolean? IsActive { get; set; }

		[JsonPropertyName("userid")]
		[JsonProperty(PropertyName = "userid")]
		public Guid? UserId { get; set; }

	}
}
