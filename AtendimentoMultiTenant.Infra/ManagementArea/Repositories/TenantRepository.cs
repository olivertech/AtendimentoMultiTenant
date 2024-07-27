namespace AtendimentoMultiTenant.Infra.ManagementArea.Repositories
{
    public class TenantRepository : RepositoryConfigurationBase<Tenant>, ITenantRepository
    {
        public TenantRepository([NotNull] ManagementAreaDbContext context) : base(context)
        {
        }
    }
}
