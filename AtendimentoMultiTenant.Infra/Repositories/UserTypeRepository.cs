namespace AtendimentoMultiTenant.Infra.Repositories
{
    public class UserTypeRepository : RepositoryConfigurationBase<UserType>, IUserTypeRepository
    {
        public UserTypeRepository([NotNull] AppDbContext context) : base(context)
        {
        }
    }
}
