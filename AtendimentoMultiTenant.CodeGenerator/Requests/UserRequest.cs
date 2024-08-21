using AtendimentoMultiTenant.Shared.ManagementArea.Interfaces;
using AtendimentoMultiTenant.Shared.ManagementArea.Requests.Base;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AtendimentoMultiTenant.Shared.ManagementArea.Requests
{
	public class UserRequest : RequestBase, IRequest
	{
		[JsonPropertyName("accesstokenid")]
		[JsonProperty(PropertyName = "accesstokenid")]
		public Guid? AccessTokenId { get; set; }

		[JsonPropertyName("createdat")]
		[JsonProperty(PropertyName = "createdat")]
		public DateOnly? CreatedAt { get; set; }

		[JsonPropertyName("deactivatedtimedat")]
		[JsonProperty(PropertyName = "deactivatedtimedat")]
		public TimeOnly? DeactivatedTimedAt { get; set; }

		[JsonPropertyName("deativatedat")]
		[JsonProperty(PropertyName = "deativatedat")]
		public DateOnly? DeativatedAt { get; set; }

		[JsonPropertyName("email")]
		[JsonProperty(PropertyName = "email")]
		public String? Email { get; set; }

		[JsonPropertyName("isactive")]
		[JsonProperty(PropertyName = "isactive")]
		public Boolean? IsActive { get; set; }

		[JsonPropertyName("name")]
		[JsonProperty(PropertyName = "name")]
		public String? Name { get; set; }

		[JsonPropertyName("password")]
		[JsonProperty(PropertyName = "password")]
		public String? Password { get; set; }

		[JsonPropertyName("roleid")]
		[JsonProperty(PropertyName = "roleid")]
		public Guid? RoleId { get; set; }

		[JsonPropertyName("tenantid")]
		[JsonProperty(PropertyName = "tenantid")]
		public Guid? TenantId { get; set; }

		[JsonPropertyName("timedat")]
		[JsonProperty(PropertyName = "timedat")]
		public TimeOnly? TimedAt { get; set; }

	}
}
