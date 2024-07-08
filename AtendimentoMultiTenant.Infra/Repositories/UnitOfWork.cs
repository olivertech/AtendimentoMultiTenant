namespace AtendimentoMultiTenant.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;

        private IContainerDbRepository? _containerRepository;
        private ITenantRepository? _tenantRepository;
        private IUserRepository? _userRepository;
        private IUserTypeRepository? _userTypeRepository;
        private IUserTokenRepository? _userTokenRepository;
        private IPortRepository? _portRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IContainerDbRepository ContainerRepository
        {
            get
            {
                return _containerRepository ??= new ContainerDbRepository(_context);
            }
        }

        public ITenantRepository TenantRepository
        {
            get
            {
                return _tenantRepository ??= new TenantRepository(_context);
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository ??= new UserRepository(_context);
            }
        }

        public IPortRepository PortRepository
        {
            get
            {
                return _portRepository ??= new PortRepository(_context);
            }
        }

        public IUserTypeRepository UserTypeRepository
        {
            get
            {
                return _userTypeRepository ??= new UserTypeRepository(_context);
            }
        }

        public IUserTokenRepository UserTokenRepository
        {
            get
            {
                return _userTokenRepository ??= new UserTokenRepository(_context);
            }
        }

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
