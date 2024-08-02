namespace AtendimentoMultiTenant.Core.ManagementArea.Interfaces
{
    public interface IUnitOfWork
    {
        IContainerDbRepository ContainerRepository { get; }
        ITenantRepository TenantRepository { get; }
        IUserRepository UserRepository { get; }
        IAccessTokenRepository TokenAccessRepository { get; }
        IPortRepository PortRepository { get; }
        IFeatureRepository FeatureRepository { get; }
        IUserFeatureRepository UserFeatureRepository { get; }
        ILogAccessRepository LogAccessRepository { get; }
        IMenuRepository MenuRepository { get; }
        IRoleMenuRepository MenuRoleRepository { get; }
        IRoleRepository RoleRepository { get; }

        Task CommitAsync();
    }
}