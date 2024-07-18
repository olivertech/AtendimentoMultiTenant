namespace AtendimentoMultiTenant.Core.Entities.ConfigurationEntities
{
    public sealed class UserFeature : ConfigurationEntityBase
    {
        public bool IsActive { get; set; }

        //Navigation Properties
        public Guid FeatureId { get; set; }
        public Feature? Feature { get; private set; }

        public Guid UserId { get; set; }
        public User? User { get; private set; }
    }
}
