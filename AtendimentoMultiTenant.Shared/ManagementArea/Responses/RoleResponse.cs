namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses
{
	public class RoleResponse : IResponse
	{
		public string? Description { get; set; }

		public Guid Id { get; set; }

		public bool IsActive { get; set; }

		public string? Name { get; set; }
	}
}
