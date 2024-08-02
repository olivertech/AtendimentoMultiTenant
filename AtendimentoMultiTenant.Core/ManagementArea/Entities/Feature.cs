namespace AtendimentoMultiTenant.Core.ManagementArea.Entities
{
    public class Feature : ConfigurationEntityBase
    {
        public string? Name { get; set; } = null!;
        public string? Description { get; set; } = null!;

        // Many-to-many relation
        public IList<UserFeature>? UserFeatures { get; set; }
    }
}
