namespace AtendimentoMultiTenant.Core.ManagementArea.Interfaces
{
    public interface ILogAccessRepository : IRepositoryConfigurationBase<LogAccess>
    {
        Task<IEnumerable<LogAccess?>> GetAllFull();
    }
}

