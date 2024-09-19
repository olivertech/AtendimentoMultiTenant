namespace AtendimentoMultiTenant.Infra.ManagementArea.Repositories
{
    public class MenuRepository : RepositoryConfigurationBase<Menu>, IMenuRepository
    {
        public MenuRepository([NotNull] ManagementAreaDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Menu?>> GetAllActivesAndInactives()
        {
            return await _context!.Menus
                .Include(p => p.RoleMenus)
                .OrderBy(p => p.Name)
                .IgnoreQueryFilters()
                .ToListAsync();
        }

        public IEnumerable<Menu?> GetAllFull(Guid roleId)
        {
            var result = (_context!.Menus.Join(
                            inner: _context.RoleMenus,
                            outerKeySelector: m => m.Id,
                            innerKeySelector: rm => rm.MenuId,
                            resultSelector: (m, rm) => new
                            {
                                m = m,
                                rm = rm
                            })
                            .Where(resultSelector => resultSelector.rm.RoleId == roleId)
                            .Select(resultSelector => resultSelector.m))
                            .OrderBy(x => x.Name)
                            .ToList();

            return result;
        }
    }
}
