﻿namespace AtendimentoMultiTenant.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
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
        }
    }
}
