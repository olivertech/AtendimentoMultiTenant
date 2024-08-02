namespace AtendimentoMultiTenant.Core.ManagementArea.Entities.Base
{
    public abstract class ConfigurationEntityBase
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
    }
}
