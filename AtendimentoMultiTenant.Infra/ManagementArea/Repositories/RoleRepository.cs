namespace AtendimentoMultiTenant.Infra.ManagementArea.Repositories
{
    public class RoleRepository : RepositoryConfigurationBase<Role>, IRoleRepository
    {
        public RoleRepository([NotNull] ManagementAreaDbContext context) : base(context)
        {
        }
    }
}
