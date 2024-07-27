using AtendimentoMultiTenant.Core.ManagementArea.Entities;

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

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ContainerDb> Containers { get; set; }
        public DbSet<Port> Ports { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<UserFeature> UserFeatures { get; set; }

        /// <summary>
        /// Faz referencia as classes de configurações das entidades
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TenantConfiguration());
            modelBuilder.ApplyConfiguration(new PortConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserTokenConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ContainerDbConfiguration());
            modelBuilder.ApplyConfiguration(new FeatureConfiguration());
            modelBuilder.ApplyConfiguration(new UserFeatureConfiguration());
        }
    }
}
