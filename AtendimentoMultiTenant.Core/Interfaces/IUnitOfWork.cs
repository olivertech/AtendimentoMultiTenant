namespace AtendimentoMultiTenant.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IContainerRepository ContainerRepository { get; }
        ITenantRepository TenantRepository { get; }
        IUserRepository UserRepository { get; }

        Task CommitAsync();
    }
}