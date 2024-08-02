namespace AtendimentoMultiTenant.Core.ManagementArea.Entities
{
    public class UserFeature : ConfigurationEntityBase
    {
        //Navigation Properties
        public Guid FeatureId { get; set; }
        public Feature? Feature { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
