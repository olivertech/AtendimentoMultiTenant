
namespace AtendimentoMultiTenant.Infra.ManagementArea.Repositories
{
    public class SecretRepository : RepositoryConfigurationBase<Secret>, ISecretRepository
    {
        public SecretRepository([NotNull] ManagementAreaDbContext context) : base(context)
        {
        }

        public async Task<Secret?> GetSecretByTenant(Guid tenantId)
        {
            return await _context!.Secrets
                .Where(x => x.TenantId!.Equals(tenantId))
                .FirstOrDefaultAsync();
        }
    }
}
