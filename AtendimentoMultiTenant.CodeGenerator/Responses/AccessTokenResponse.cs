using AtendimentoMultiTenant.Shared.ManagementArea.Interfaces;
using Newtonsoft.Json;

namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses
{
	public class AccessTokenResponse : IResponse
	{
		[JsonProperty(PropertyName = "createdat")]
		public DateOnly? CreatedAt { get; set; }

		[JsonProperty(PropertyName = "expiringat")]
		public DateOnly? ExpiringAt { get; set; }

		[JsonProperty(PropertyName = "id")]
		public Guid? Id { get; set; }

		[JsonProperty(PropertyName = "isactive")]
		public Boolean? IsActive { get; set; }

		[JsonProperty(PropertyName = "timedat")]
		public TimeOnly? TimedAt { get; set; }

		[JsonProperty(PropertyName = "token")]
		public String? Token { get; set; }

	}
}
