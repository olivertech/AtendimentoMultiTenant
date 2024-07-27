namespace AtendimentoMultiTenant.Infra.ManagementArea.Repositories
{
    public class ContainerDbRepository : RepositoryConfigurationBase<ContainerDb>, IContainerDbRepository
    {
        public ContainerDbRepository([NotNull] ManagementAreaDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ContainerDb?>> GetAllFull()
        {
            return await _context!.Containers
                .Include(p => p.Port)
                .Include(t => t.Tenant)
                .ToListAsync();
        }
    }
}
