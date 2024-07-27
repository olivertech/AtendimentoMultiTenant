using AtendimentoMultiTenant.Core.ManagementArea.Entities.Base;

namespace AtendimentoMultiTenant.Core.ManagementArea.Entities
{
    public sealed class Feature : ConfigurationEntityBase
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        // Many-to-many relation
        public IList<UserFeature>? UserFeatures { get; set; }
    }
}
