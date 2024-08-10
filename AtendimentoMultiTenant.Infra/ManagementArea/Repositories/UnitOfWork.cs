﻿namespace AtendimentoMultiTenant.Infra.ManagementArea.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ManagementAreaDbContext _context;

        private IContainerDbRepository? _containerDbRepository;
        private ITenantRepository? _tenantRepository;
        private IUserRepository? _userRepository;
        private IAccessTokenRepository? _tokenAccessRepository;
        private IPortRepository? _portRepository;
        private IFeatureRepository? _featureRepository;
        private IUserFeatureRepository? _userFeatureRepository;
        private ILogAccessRepository? _logAccessRepository;
        private IMenuRepository? _menuRepository;
        private IRoleMenuRepository? _menuRoleRepository;
        private IRoleRepository? _roleRepository;

        public UnitOfWork(ManagementAreaDbContext context)
        {
            _context = context;
        }

        public IContainerDbRepository ContainerDbRepository => _containerDbRepository ??= new ContainerDbRepository(_context);

        public ITenantRepository TenantRepository => _tenantRepository ??= new TenantRepository(_context);

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);
        
        public IPortRepository PortRepository => _portRepository ??= new PortRepository(_context);

        public IAccessTokenRepository TokenAccessRepository => _tokenAccessRepository ??= new AccessTokenRepository(_context);

        public IFeatureRepository FeatureRepository => _featureRepository ??= new FeatureRepository(_context);
        
        public IUserFeatureRepository UserFeatureRepository => _userFeatureRepository ??= new UserFeatureRepository(_context);

        public ILogAccessRepository LogAccessRepository => _logAccessRepository ??= new LogAccessRepository(_context);

        public IMenuRepository MenuRepository => _menuRepository ??= new MenuRepository(_context);

        public IRoleMenuRepository MenuRoleRepository => _menuRoleRepository ??= new RoleMenuRepository(_context);

        public IRoleRepository RoleRepository => _roleRepository ??= new RoleRepository(_context);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
