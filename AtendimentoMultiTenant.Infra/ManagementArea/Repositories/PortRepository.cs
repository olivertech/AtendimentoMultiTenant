namespace AtendimentoMultiTenant.Infra.ManagementArea.Repositories
{
    public class PortRepository : RepositoryConfigurationBase<Port>, IPortRepository
    {
        public PortRepository([NotNull] ManagementAreaDbContext context) : base(context)
        {
        }
    }
}
