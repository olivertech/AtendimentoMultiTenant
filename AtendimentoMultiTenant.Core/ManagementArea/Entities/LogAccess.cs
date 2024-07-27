namespace AtendimentoMultiTenant.Core.ManagementArea.Entities
{
    public sealed class LogAccess : ConfigurationEntityBase
    {
        public Guid UserId { get; set; }
        public Guid TokenId { get; set; }
        public DateTime AccessDateTime { get; set; }

        //Navigation Property
        public UserToken? UserToken { get; set; }
        public User? User { get; set; }
    }
}
