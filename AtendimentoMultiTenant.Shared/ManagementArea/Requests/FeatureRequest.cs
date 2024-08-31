namespace AtendimentoMultiTenant.Shared.ManagementArea.Requests
{
	public class FeatureRequest : RequestBase, IRequest
	{
		[JsonPropertyName("description")]
		[JsonProperty(PropertyName = "description")]
		public String? Description { get; set; }

		[JsonPropertyName("isactive")]
		[JsonProperty(PropertyName = "isactive")]
		public Boolean? IsActive { get; set; }

		[JsonPropertyName("name")]
		[JsonProperty(PropertyName = "name")]
		public String? Name { get; set; }

	}
}
