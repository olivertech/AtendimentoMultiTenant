namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses
{
	public class RoleMenuResponse : IResponse
	{
		public Guid Id { get; set; }

		public Boolean? IsActive { get; set; }

		public Guid MenuId { get; set; }

		public Guid RoleId { get; set; }
	}
}
