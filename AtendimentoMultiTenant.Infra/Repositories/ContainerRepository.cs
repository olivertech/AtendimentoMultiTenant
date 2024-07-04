namespace AtendimentoMultiTenant.Infra.Repositories
{
    public class ContainerRepository : RepositoryConfigurationBase<Container>, IContainerRepository
    {
        public ContainerRepository([NotNull] AppDbContext context) : base(context)
        {
        }
    }
}
