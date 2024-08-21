using AtendimentoMultiTenant.Shared.ManagementArea.Interfaces;
using Newtonsoft.Json;

namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses
{
	public class UserResponse : IResponse
	{
		[JsonProperty(PropertyName = "accesstokenid")]
		public Guid? AccessTokenId { get; set; }

		[JsonProperty(PropertyName = "createdat")]
		public DateOnly? CreatedAt { get; set; }

		[JsonProperty(PropertyName = "deactivatedtimedat")]
		public TimeOnly? DeactivatedTimedAt { get; set; }

		[JsonProperty(PropertyName = "deativatedat")]
		public DateOnly? DeativatedAt { get; set; }

		[JsonProperty(PropertyName = "email")]
		public String? Email { get; set; }

		[JsonProperty(PropertyName = "id")]
		public Guid? Id { get; set; }

		[JsonProperty(PropertyName = "isactive")]
		public Boolean? IsActive { get; set; }

		[JsonProperty(PropertyName = "name")]
		public String? Name { get; set; }

		[JsonProperty(PropertyName = "password")]
		public String? Password { get; set; }

		[JsonProperty(PropertyName = "roleid")]
		public Guid? RoleId { get; set; }

		[JsonProperty(PropertyName = "tenantid")]
		public Guid? TenantId { get; set; }

		[JsonProperty(PropertyName = "timedat")]
		public TimeOnly? TimedAt { get; set; }

	}
}
