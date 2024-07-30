﻿namespace AtendimentoMultiTenant.Core.ManagementArea.Interfaces
{
    public interface IUnitOfWork
    {
        IContainerDbRepository ContainerRepository { get; }
        ITenantRepository TenantRepository { get; }
        IUserRepository UserRepository { get; }
        IUserTypeRepository UserTypeRepository { get; }
        IUserTokenRepository UserTokenRepository { get; }
        IPortRepository PortRepository { get; }
        IFeatureRepository FeatureRepository { get; }
        IUserFeatureRepository UserFeatureRepository { get; }
        ILogAccessRepository LogAccessRepository { get; }
        IMenuRepository MenuRepository { get; }
        IMenuRoleRepository MenuRoleRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }

        Task CommitAsync();
    }
}