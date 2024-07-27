namespace AtendimentoMultiTenant.Infra.ManagementArea.Repositories
{
    public class UserTypeRepository : RepositoryConfigurationBase<UserType>, IUserTypeRepository
    {
        public UserTypeRepository([NotNull] ManagementAreaDbContext context) : base(context)
        {
        }
    }
}
