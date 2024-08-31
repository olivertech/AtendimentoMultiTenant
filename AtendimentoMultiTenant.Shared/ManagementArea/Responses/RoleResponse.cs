namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses
{
	public class RoleResponse : IResponse
	{
		[JsonProperty(PropertyName = "description")]
		public string? Description { get; set; }

		[JsonProperty(PropertyName = "id")]
		public Guid Id { get; set; }

		[JsonProperty(PropertyName = "isactive")]
		public bool IsActive { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string? Name { get; set; }

	}
}
