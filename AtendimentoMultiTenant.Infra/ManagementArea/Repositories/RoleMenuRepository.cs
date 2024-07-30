namespace AtendimentoMultiTenant.Infra.ManagementArea.Repositories
{
    public class RoleMenuRepository : RepositoryConfigurationBase<RoleMenu>, IRoleMenuRepository
    {
        public RoleMenuRepository([NotNull] ManagementAreaDbContext context) : base(context)
        {
        }
    }
}
