namespace AtendimentoMultiTenant.Infra.ManagementArea.Repositories
{
    public class MenuRoleRepository : RepositoryConfigurationBase<MenuRole>, IMenuRoleRepository
    {
        public MenuRoleRepository([NotNull] ManagementAreaDbContext context) : base(context)
        {
        }
    }
}
