namespace AtendimentoMultiTenant.Core.ManagementArea.Entities
{
    public sealed class UserRole : ConfigurationEntityBase
    {
        public bool IsActive { get; set; }

        //Navigation Properties
        public Guid RoleId { get; set; }
        public Role? Role { get; private set; }

        public Guid UserId { get; set; }
        public User? User { get; private set; }
    }
}
