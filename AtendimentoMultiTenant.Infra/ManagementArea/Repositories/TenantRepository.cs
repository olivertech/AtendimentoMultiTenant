namespace AtendimentoMultiTenant.Infra.ManagementArea.Repositories
{
    public class TenantRepository : RepositoryConfigurationBase<Tenant>, ITenantRepository
    {
        public TenantRepository([NotNull] ManagementAreaDbContext context) : base(context)
        {
        }

        public async Task<Tenant?> GetTenantBySecret(string secret)
        {
            return await _context!.Tenants
                .Where(x => x.Secret!.Equals(secret))
                .FirstOrDefaultAsync();
        }
    }
}
