namespace AtendimentoMultiTenant.Infra.Repositories
{
    public class FeatureRepository : RepositoryConfigurationBase<Feature>, IFeatureRepository
    {
        public FeatureRepository([NotNull] AppDbContext context) : base(context)
        {
        }
    }
}
