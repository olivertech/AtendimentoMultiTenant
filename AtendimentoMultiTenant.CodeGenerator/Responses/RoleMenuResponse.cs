using AtendimentoMultiTenant.Shared.ManagementArea.Interfaces;
using Newtonsoft.Json;

namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses
{
	public class RoleMenuResponse : IResponse
	{
		[JsonProperty(PropertyName = "id")]
		public Guid? Id { get; set; }

		[JsonProperty(PropertyName = "isactive")]
		public Boolean? IsActive { get; set; }

		[JsonProperty(PropertyName = "menuid")]
		public Guid? MenuId { get; set; }

		[JsonProperty(PropertyName = "roleid")]
		public Guid? RoleId { get; set; }

	}
}
