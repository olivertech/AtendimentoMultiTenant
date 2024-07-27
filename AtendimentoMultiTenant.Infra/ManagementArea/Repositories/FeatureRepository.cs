namespace AtendimentoMultiTenant.Infra.ManagementArea.Repositories
{
    public class FeatureRepository : RepositoryConfigurationBase<Feature>, IFeatureRepository
    {
        public FeatureRepository([NotNull] ManagementAreaDbContext context) : base(context)
        {
        }
    }
}
