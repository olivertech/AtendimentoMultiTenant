namespace AtendimentoMultiTenant.Core.ManagementArea.Entities
{
    public class Secret : ConfigurationEntityBase
    {
        public string? SecretKey { get; set; } = null!;

        public Guid TenantId { get; set; }

        //Navigation Property
        public Tenant? Tenant { get; set; } = null!;
    }
}
