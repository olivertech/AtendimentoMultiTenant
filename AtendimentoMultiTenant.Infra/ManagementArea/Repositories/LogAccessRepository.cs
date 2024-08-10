
namespace AtendimentoMultiTenant.Infra.ManagementArea.Repositories
{
    public class LogAccessRepository : RepositoryConfigurationBase<LogAccess>, ILogAccessRepository
    {
        public LogAccessRepository([NotNull] ManagementAreaDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<LogAccess?>> GetAllFull()
        {
            return await _context!.LogAccesses
                .Include(u => u.User)
                .ThenInclude(t => t!.Tenant)
                .ToListAsync();
        }
    }
}
