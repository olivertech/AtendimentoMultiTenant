namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses
{
	public class UserResponse : IResponse
	{
		public Guid AccessTokenId { get; set; }

		public DateOnly? CreatedAt { get; set; }

		public TimeOnly? DeactivatedTimedAt { get; set; }

		public DateOnly? DeativatedAt { get; set; }

		public String? Email { get; set; }

		public Guid Id { get; set; }

		public Boolean? IsActive { get; set; }

		public String? Name { get; set; }

		public String? Password { get; set; }

		public Guid RoleId { get; set; }

		public Guid TenantId { get; set; }

		public TimeOnly? TimedAt { get; set; }
	}
}
