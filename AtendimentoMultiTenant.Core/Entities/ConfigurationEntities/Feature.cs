namespace AtendimentoMultiTenant.Core.Entities.ConfigurationEntities
{
    public class Feature : ConfigurationEntityBase
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        // Many-to-many relation
        public IList<UserFeature>? UserFeatures { get; set; }
    }
}
