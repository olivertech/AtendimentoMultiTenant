using AtendimentoMultiTenant.Core.ManagementArea.Entities.Base;

namespace AtendimentoMultiTenant.Core.ManagementArea.Entities
{
    public sealed class UserType : ConfigurationEntityBase
    {
        public string? Name { get; set; } = null;
    }
}
