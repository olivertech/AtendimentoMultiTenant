namespace AtendimentoMultiTenant.Core.ManagementArea.Entities
{
    public sealed class RoleMenu : ConfigurationEntityBase
    {
        public bool IsActive { get; set; }

        //Navigation Properties
        public Guid RoleId { get; set; }
        public Role? Role { get; private set; }

        public Guid MenuId { get; set; }
        public Menu? Menu { get; private set; }
    }
}
