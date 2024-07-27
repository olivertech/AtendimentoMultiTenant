namespace AtendimentoMultiTenant.Infra.ManagementArea.Repositories
{
    public class LogAccessRepository : RepositoryConfigurationBase<LogAccess>, ILogAccessRepository
    {
        public LogAccessRepository([NotNull] ManagementAreaDbContext context) : base(context)
        {
        }
    }
}
