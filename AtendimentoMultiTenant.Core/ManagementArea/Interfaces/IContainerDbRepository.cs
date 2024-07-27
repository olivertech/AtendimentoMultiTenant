namespace AtendimentoMultiTenant.Core.ManagementArea.Interfaces
{
    public interface IContainerDbRepository : IRepositoryConfigurationBase<ContainerDb>
    {
        Task<IEnumerable<ContainerDb?>> GetAllFull();
    }
}
