namespace AtendimentoMultiTenant.Infra.Repositories
{
    public class PortRepository : RepositoryConfigurationBase<Port>, IPortRepository
    {
        public PortRepository([NotNull] AppDbContext context) : base(context)
        {
        }
    }
}
