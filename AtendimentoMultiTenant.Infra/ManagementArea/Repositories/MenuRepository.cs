namespace AtendimentoMultiTenant.Infra.ManagementArea.Repositories
{
    public class MenuRepository : RepositoryConfigurationBase<Menu>, IMenuRepository
    {
        public MenuRepository([NotNull] ManagementAreaDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Menu?>> GetAllFull()
        {
            return await _context!.Menus
                .Include(p => p.RoleMenus)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }
    }
}
