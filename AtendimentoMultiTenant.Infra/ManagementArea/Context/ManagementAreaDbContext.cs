namespace AtendimentoMultiTenant.Infra.ManagementArea.Context
{
    public class ManagementAreaDbContext : DbContext
    {
        public ManagementAreaDbContext(DbContextOptions<ManagementAreaDbContext> options)
            : base(options)
        {
        }

        //===========
        // Entidades
        //===========

        public DbSet<AccessToken> AccessTokens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ContainerDb> Containers { get; set; }
        public DbSet<Port> Ports { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<UserFeature> UserFeatures { get; set; }
        public DbSet<LogAccess> LogAccesses { get; set; }
        public DbSet<Role> UserRoles { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        /// <summary>
        /// Faz referencia as classes de configurações das entidades
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ContainerDbConfiguration());
            //modelBuilder.ApplyConfiguration(new FeatureConfiguration());
            //modelBuilder.ApplyConfiguration(new LogAccessConfiguration());
            //modelBuilder.ApplyConfiguration(new MenuConfiguration());
            //modelBuilder.ApplyConfiguration(new PortConfiguration());
            //modelBuilder.ApplyConfiguration(new RoleConfiguration());
            //modelBuilder.ApplyConfiguration(new RoleMenuConfiguration());
            //modelBuilder.ApplyConfiguration(new TenantConfiguration());
            //modelBuilder.ApplyConfiguration(new TokenAccessConfiguration());
            //modelBuilder.ApplyConfiguration(new UserConfiguration());
            //modelBuilder.ApplyConfiguration(new UserFeatureConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
