namespace AtendimentoMultiTenant.Core.ManagementArea.Interfaces
{
    public interface IMenuRepository : IRepositoryConfigurationBase<Menu>
    {
        Task<IEnumerable<Menu?>> GetAllActivesAndInactives();
        Task<IEnumerable<Menu?>> GetAllFull();
    }
}
