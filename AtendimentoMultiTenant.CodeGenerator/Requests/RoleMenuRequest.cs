using AtendimentoMultiTenant.Shared.ManagementArea.Interfaces;
using AtendimentoMultiTenant.Shared.ManagementArea.Requests.Base;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

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
