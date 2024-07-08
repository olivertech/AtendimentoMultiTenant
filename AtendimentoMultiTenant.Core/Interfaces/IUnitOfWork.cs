namespace AtendimentoMultiTenant.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IContainerDbRepository ContainerRepository { get; }
        ITenantRepository TenantRepository { get; }
        IUserRepository UserRepository { get; }
        IUserTypeRepository UserTypeRepository { get; }
        IUserTokenRepository UserTokenRepository { get; }
        IPortRepository PortRepository { get; }

        Task CommitAsync();
    }
}