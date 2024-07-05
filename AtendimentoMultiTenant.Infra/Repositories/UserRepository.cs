namespace AtendimentoMultiTenant.Infra.Repositories
{
    public class UserRepository : RepositoryConfigurationBase<User>, IUserRepository
    {
        public UserRepository([NotNull] AppDbContext context) : base(context)
        {
        }
    }
}
