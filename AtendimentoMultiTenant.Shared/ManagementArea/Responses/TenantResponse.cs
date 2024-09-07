namespace AtendimentoMultiTenant.Shared.ManagementArea.Responses
{
    public class TenantResponse : IResponse
    {
        public string? Name { get; set; } = null!;

        public string? Secret { get; set; } = null!;

        public DateOnly? DeativatedAt { get; set; }

        public TimeOnly? DeactivatedTimedAt { get; set; }
    }
}
