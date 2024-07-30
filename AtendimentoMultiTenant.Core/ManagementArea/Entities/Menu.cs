namespace AtendimentoMultiTenant.Core.ManagementArea.Entities
{
    public sealed class Menu : ConfigurationEntityBase
    {
        public string? Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public bool IsActive { get; set; }

        // Many-to-many relation
        public IList<MenuRole>? RoleMenus { get; set; }
    }
}
