namespace AtendimentoMultiTenant.Core.ManagementArea.Interfaces
{
    public interface IMenuRepository : IRepositoryConfigurationBase<Menu>
    {
        Task<IEnumerable<Menu?>> GetAllActivesAndInactives();
        IEnumerable<Menu?> GetAllFull(Guid roleId);
    }
}
