namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses
{
    public class TenantResponse : IResponse
    {
        public Guid Id { get; set; }

        public string? Name { get; set; } = null!;

        public string? Description { get; set; } = null;

        public string? ConnectionString { get; set; } = null!;

        public string? InitialUrl { get; set; } = null;

        public bool IsActive { get; set; }

        public DateOnly? DeativatedAt { get; set; }

        public TimeOnly? DeactivatedTimedAt { get; set; }
    }
}
