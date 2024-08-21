using AtendimentoMultiTenant.Shared.ManagementArea.Interfaces;
using Newtonsoft.Json;

namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses
{
	public class ContainerDbResponse : IResponse
	{
		[JsonProperty(PropertyName = "containerdbimage")]
		public String? ContainerDbImage { get; set; }

		[JsonProperty(PropertyName = "containerdbname")]
		public String? ContainerDbName { get; set; }

		[JsonProperty(PropertyName = "containerdbnetwork")]
		public String? ContainerDbNetwork { get; set; }

		[JsonProperty(PropertyName = "containerdbport")]
		public String? ContainerDbPort { get; set; }

		[JsonProperty(PropertyName = "containerdbvolume")]
		public String? ContainerDbVolume { get; set; }

		[JsonProperty(PropertyName = "createdat")]
		public DateOnly? CreatedAt { get; set; }

		[JsonProperty(PropertyName = "deactivatedtimedat")]
		public TimeOnly? DeactivatedTimedAt { get; set; }

		[JsonProperty(PropertyName = "deativatedat")]
		public DateOnly? DeativatedAt { get; set; }

		[JsonProperty(PropertyName = "environmentdbname")]
		public String? EnvironmentDbName { get; set; }

		[JsonProperty(PropertyName = "environmentdbpwd")]
		public String? EnvironmentDbPwd { get; set; }

		[JsonProperty(PropertyName = "environmentdbuser")]
		public String? EnvironmentDbUser { get; set; }

		[JsonProperty(PropertyName = "id")]
		public Guid? Id { get; set; }

		[JsonProperty(PropertyName = "isactive")]
		public Boolean? IsActive { get; set; }

		[JsonProperty(PropertyName = "isup")]
		public Boolean? IsUp { get; set; }

		[JsonProperty(PropertyName = "portid")]
		public Guid? PortId { get; set; }

		[JsonProperty(PropertyName = "tenantid")]
		public Guid? TenantId { get; set; }

		[JsonProperty(PropertyName = "timedat")]
		public TimeOnly? TimedAt { get; set; }

	}
}
