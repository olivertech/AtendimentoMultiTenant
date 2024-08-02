namespace AtendimentoMultiTenant.Core.ManagementArea.Entities
{
    public class RoleMenu : ConfigurationEntityBase
    {
        //Navigation Properties
        public Guid RoleId { get; set; }
        public Role? Role { get; set; }

        public Guid MenuId { get; set; }
        public Menu? Menu { get; set; }
    }
}
