namespace AtendimentoMultiTenant.Infra.ManagementArea.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ManagementAreaDbContext _context;

        private IContainerDbRepository? _containerRepository;
        private ITenantRepository? _tenantRepository;
        private IUserRepository? _userRepository;
        private IUserTypeRepository? _userTypeRepository;
        private IUserTokenRepository? _userTokenRepository;
        private IPortRepository? _portRepository;
        private IFeatureRepository? _featureRepository;
        private IUserFeatureRepository? _userFeatureRepository;
        private ILogAccessRepository? _logAccessRepository;

        public UnitOfWork(ManagementAreaDbContext context)
        {
            _context = context;
        }

        public IContainerDbRepository ContainerRepository => _containerRepository ??= new ContainerDbRepository(_context);

        public ITenantRepository TenantRepository => _tenantRepository ??= new TenantRepository(_context);

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);

        public IPortRepository PortRepository => _portRepository ??= new PortRepository(_context);

        public IUserTypeRepository UserTypeRepository => _userTypeRepository ??= new UserTypeRepository(_context);
        
        public IUserTokenRepository UserTokenRepository => _userTokenRepository ??= new UserTokenRepository(_context);

        public IFeatureRepository FeatureRepository => _featureRepository ??= new FeatureRepository(_context);
        
        public IUserFeatureRepository UserFeatureRepository => _userFeatureRepository ??= new UserFeatureRepository(_context);

        public ILogAccessRepository LogAccessRepository => _logAccessRepository ??= new LogAccessRepository(_context);

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
