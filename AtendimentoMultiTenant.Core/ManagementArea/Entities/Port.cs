namespace AtendimentoMultiTenant.Core.ManagementArea.Entities
{
    public sealed class Port : ConfigurationEntityBase
    {
        public string? PortNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
