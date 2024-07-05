namespace AtendimentoMultiTenant.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;

        private IContainerRepository? _containerRepository;
        private ITenantRepository? _tenantRepository;
        private IUserRepository? _userRepository;
        private IPortRepository? _portRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IContainerRepository ContainerRepository
        {
            get
            {
                return _containerRepository ??= new ContainerRepository(_context);
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
