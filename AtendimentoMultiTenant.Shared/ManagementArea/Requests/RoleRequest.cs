namespace AtendimentoMultiTenant.Shared.ManagementArea.Requests
{
	public class RoleRequest : RequestBase, IRequest
	{
		[JsonPropertyName("description")]
		[JsonProperty(PropertyName = "description")]
		public string? Description { get; set; }

		[JsonPropertyName("isactive")]
		[JsonProperty(PropertyName = "isactive")]
		public bool IsActive { get; set; }

		[JsonPropertyName("name")]
		[JsonProperty(PropertyName = "name")]
		public string? Name { get; set; }

	}
}
