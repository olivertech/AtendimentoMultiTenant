namespace AtendimentoMultiTenant.Core.ManagementArea.Entities
{
    public sealed class Role : ConfigurationEntityBase
    {
        public string? Name { get; set; } = null!;
        public string? Description { get; set; } = null!;

        // Many-to-many relation
        public IList<RoleMenu>? MenuRoles { get; set; }
    }
}
