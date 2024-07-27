namespace AtendimentoMultiTenant.Infra.ManagementArea.Repositories
{
    public class UserFeatureRepository : RepositoryConfigurationBase<UserFeature>, IUserFeatureRepository
    {
        public UserFeatureRepository([NotNull] ManagementAreaDbContext context) : base(context)
        {
        }
    }
}
