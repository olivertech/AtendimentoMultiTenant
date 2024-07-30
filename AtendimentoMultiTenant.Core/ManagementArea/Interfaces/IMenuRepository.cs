namespace AtendimentoMultiTenant.Core.ManagementArea.Interfaces
{
    public interface IMenuRepository : IRepositoryConfigurationBase<Menu>
    {
        Task<IEnumerable<Menu?>> GetAllFull();
    }
}
