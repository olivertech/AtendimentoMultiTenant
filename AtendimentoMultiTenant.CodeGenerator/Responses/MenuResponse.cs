using AtendimentoMultiTenant.Shared.ManagementArea.Interfaces;
using Newtonsoft.Json;

namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses
{
	public class MenuResponse : IResponse
	{
		[JsonProperty(PropertyName = "description")]
		public String? Description { get; set; }

		[JsonProperty(PropertyName = "icone")]
		public String? Icone { get; set; }

		[JsonProperty(PropertyName = "id")]
		public Guid? Id { get; set; }

		[JsonProperty(PropertyName = "isactive")]
		public Boolean? IsActive { get; set; }

		[JsonProperty(PropertyName = "name")]
		public String? Name { get; set; }

		[JsonProperty(PropertyName = "route")]
		public String? Route { get; set; }

	}
}
