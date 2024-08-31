namespace AtendimentoMultiTenant.Shared.ManagementArea.Requests
{
	public class RoleMenuRequest : RequestBase, IRequest
	{
		[JsonPropertyName("isactive")]
		[JsonProperty(PropertyName = "isactive")]
		public Boolean? IsActive { get; set; }

		[JsonPropertyName("menuid")]
		[JsonProperty(PropertyName = "menuid")]
		public Guid? MenuId { get; set; }

		[JsonPropertyName("roleid")]
		[JsonProperty(PropertyName = "roleid")]
		public Guid? RoleId { get; set; }

	}
}
