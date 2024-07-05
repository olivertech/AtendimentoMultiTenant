namespace AtendimentoMultiTenant.Infra.Repositories
{
    public class TenantRepository : RepositoryConfigurationBase<Tenant>, ITenantRepository
    {
        public TenantRepository([NotNull] AppDbContext context) : base(context)
        {
        }
    }
}
