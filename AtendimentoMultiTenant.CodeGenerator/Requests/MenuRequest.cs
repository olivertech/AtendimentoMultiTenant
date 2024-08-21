using AtendimentoMultiTenant.Shared.ManagementArea.Interfaces;
using AtendimentoMultiTenant.Shared.ManagementArea.Requests.Base;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AtendimentoMultiTenant.Shared.ManagementArea.Requests
{
	public class MenuRequest : RequestBase, IRequest
	{
		[JsonPropertyName("description")]
		[JsonProperty(PropertyName = "description")]
		public String? Description { get; set; }

		[JsonPropertyName("icone")]
		[JsonProperty(PropertyName = "icone")]
		public String? Icone { get; set; }

		[JsonPropertyName("isactive")]
		[JsonProperty(PropertyName = "isactive")]
		public Boolean? IsActive { get; set; }

		[JsonPropertyName("name")]
		[JsonProperty(PropertyName = "name")]
		public String? Name { get; set; }

		[JsonPropertyName("route")]
		[JsonProperty(PropertyName = "route")]
		public String? Route { get; set; }

	}
}
