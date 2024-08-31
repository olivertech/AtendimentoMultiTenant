using AtendimentoMultiTenant.Shared.ManagementArea.Interfaces;
using Newtonsoft.Json;

namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses
{
	public class TenantResponse : IResponse
	{
		[JsonProperty(PropertyName = "connectionstring")]
		public String? ConnectionString { get; set; }

		[JsonProperty(PropertyName = "createdat")]
		public DateOnly? CreatedAt { get; set; }

		[JsonProperty(PropertyName = "deactivatedtimedat")]
		public TimeOnly? DeactivatedTimedAt { get; set; }

		[JsonProperty(PropertyName = "deativatedat")]
		public DateOnly? DeativatedAt { get; set; }

		[JsonProperty(PropertyName = "id")]
		public Guid? Id { get; set; }

		[JsonProperty(PropertyName = "initialurl")]
		public String? InitialUrl { get; set; }

		[JsonProperty(PropertyName = "isactive")]
		public Boolean? IsActive { get; set; }

		[JsonProperty(PropertyName = "name")]
		public String? Name { get; set; }

		[JsonProperty(PropertyName = "timedat")]
		public TimeOnly? TimedAt { get; set; }

	}
}
