using AtendimentoMultiTenant.Shared.ManagementArea.Interfaces;
using AtendimentoMultiTenant.Shared.ManagementArea.Requests.Base;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AtendimentoMultiTenant.Shared.ManagementArea.Requests
{
	public class ContainerDbRequest : RequestBase, IRequest
	{
		[JsonPropertyName("containerdbimage")]
		[JsonProperty(PropertyName = "containerdbimage")]
		public String? ContainerDbImage { get; set; }

		[JsonPropertyName("containerdbname")]
		[JsonProperty(PropertyName = "containerdbname")]
		public String? ContainerDbName { get; set; }

		[JsonPropertyName("containerdbnetwork")]
		[JsonProperty(PropertyName = "containerdbnetwork")]
		public String? ContainerDbNetwork { get; set; }

		[JsonPropertyName("containerdbport")]
		[JsonProperty(PropertyName = "containerdbport")]
		public String? ContainerDbPort { get; set; }

		[JsonPropertyName("containerdbvolume")]
		[JsonProperty(PropertyName = "containerdbvolume")]
		public String? ContainerDbVolume { get; set; }

		[JsonPropertyName("createdat")]
		[JsonProperty(PropertyName = "createdat")]
		public DateOnly? CreatedAt { get; set; }

		[JsonPropertyName("deactivatedtimedat")]
		[JsonProperty(PropertyName = "deactivatedtimedat")]
		public TimeOnly? DeactivatedTimedAt { get; set; }

		[JsonPropertyName("deativatedat")]
		[JsonProperty(PropertyName = "deativatedat")]
		public DateOnly? DeativatedAt { get; set; }

		[JsonPropertyName("environmentdbname")]
		[JsonProperty(PropertyName = "environmentdbname")]
		public String? EnvironmentDbName { get; set; }

		[JsonPropertyName("environmentdbpwd")]
		[JsonProperty(PropertyName = "environmentdbpwd")]
		public String? EnvironmentDbPwd { get; set; }

		[JsonPropertyName("environmentdbuser")]
		[JsonProperty(PropertyName = "environmentdbuser")]
		public String? EnvironmentDbUser { get; set; }

		[JsonPropertyName("isactive")]
		[JsonProperty(PropertyName = "isactive")]
		public Boolean? IsActive { get; set; }

		[JsonPropertyName("isup")]
		[JsonProperty(PropertyName = "isup")]
		public Boolean? IsUp { get; set; }

		[JsonPropertyName("portid")]
		[JsonProperty(PropertyName = "portid")]
		public Guid? PortId { get; set; }

		[JsonPropertyName("tenantid")]
		[JsonProperty(PropertyName = "tenantid")]
		public Guid? TenantId { get; set; }

		[JsonPropertyName("timedat")]
		[JsonProperty(PropertyName = "timedat")]
		public TimeOnly? TimedAt { get; set; }

	}
}
