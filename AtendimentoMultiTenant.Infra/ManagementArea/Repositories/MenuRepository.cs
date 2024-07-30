namespace AtendimentoMultiTenant.Infra.ManagementArea.Repositories
{
    public class MenuRepository : RepositoryConfigurationBase<Menu>, IMenuRepository
    {
        public MenuRepository([NotNull] ManagementAreaDbContext context) : base(context)
        {
        }
    }
}
