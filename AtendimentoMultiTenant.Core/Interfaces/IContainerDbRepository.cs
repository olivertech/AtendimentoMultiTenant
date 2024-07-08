namespace AtendimentoMultiTenant.Core.Interfaces
{
    public interface IContainerDbRepository : IRepositoryConfigurationBase<ContainerDb>
    {
        Task<IEnumerable<ContainerDb?>> GetAllFull();
    }
}
