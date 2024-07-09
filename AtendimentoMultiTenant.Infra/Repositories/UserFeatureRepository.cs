namespace AtendimentoMultiTenant.Infra.Repositories
{
    public class UserFeatureRepository : RepositoryConfigurationBase<UserFeature>, IUserFeatureRepository
    {
        public UserFeatureRepository([NotNull] AppDbContext context) : base(context)
        {
        }
    }
}
