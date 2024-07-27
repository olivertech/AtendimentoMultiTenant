namespace AtendimentoMultiTenant.Core.ManagementArea.Entities
{
    public sealed class LogAccess : ConfigurationEntityBase
    {
        public Guid UserId { get; set; }
        public DateOnly? CreatedAt { get; set; }

        //Navigation Property
        public User? User { get; set; }
    }
}
