namespace AtendimentoMultiTenant.Core.ManagementArea.Entities
{
    public sealed class UserType : ConfigurationEntityBase
    {
        public string? Name { get; set; } = null;
        public string? Description { get; set; } = null;
    }
}
