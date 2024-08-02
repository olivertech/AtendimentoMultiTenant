namespace AtendimentoMultiTenant.Core.ManagementArea.Entities
{
    public sealed class Menu : ConfigurationEntityBase
    {
        public string? Name { get; set; } = null!;
        public string? Description { get; set; } = null!;

        // Many-to-many relation
        public IList<RoleMenu>? RoleMenus { get; set; }
    }
}
