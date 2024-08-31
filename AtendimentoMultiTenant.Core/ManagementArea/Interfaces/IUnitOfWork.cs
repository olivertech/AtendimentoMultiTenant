namespace AtendimentoMultiTenant.Core.ManagementArea.Interfaces
{
    public interface IUnitOfWork
    {
        IContainerDbRepository ContainerDbRepository { get; }
        ITenantRepository TenantRepository { get; }
        IUserRepository UserRepository { get; }
        IAccessTokenRepository AccessTokenRepository { get; }
        IPortRepository PortRepository { get; }
        IFeatureRepository FeatureRepository { get; }
        IUserFeatureRepository UserFeatureRepository { get; }
        ILogAccessRepository LogAccessRepository { get; }
        IMenuRepository MenuRepository { get; }
        IRoleMenuRepository RoleMenuRepository { get; }
        IRoleRepository RoleRepository { get; }
        ISecretRepository SecretRepository { get; }

        Task CommitAsync();
    }
}