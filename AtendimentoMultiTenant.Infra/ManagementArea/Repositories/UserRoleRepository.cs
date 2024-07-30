namespace AtendimentoMultiTenant.Infra.ManagementArea.Repositories
{
    public class UserRoleRepository : RepositoryConfigurationBase<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository([NotNull] ManagementAreaDbContext context) : base(context)
        {
        }
    }
}
