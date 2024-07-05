namespace AtendimentoMultiTenant.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IContainerRepository ContainerRepository { get; }
        ITenantRepository TenantRepository { get; }
        IUserRepository UserRepository { get; }
        IPortRepository PortRepository { get; }

        Task CommitAsync();
    }
}