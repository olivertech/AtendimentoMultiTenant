namespace AtendimentoMultiTenant.Infra.EntityConfigurations
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Secret).HasColumnName("secret").HasMaxLength(20).IsRequired();
            builder.Property(x => x.ConnectionString).HasColumnName("connection_string").IsRequired();
            builder.Property(x => x.InitialUrl).HasColumnName("initial_url").IsRequired();
            builder.Property(x => x.IsActive).HasColumnName("is_active").IsRequired().HasDefaultValue(true);
            builder.ToTable("Tenant");

            //TODO: Seed para fins de testes... No final, esse Seed deverá ser removido
            builder.HasData(new[]
            {
                new Tenant
                {
                    Id = Guid.Parse("f6a2372a-b146-45f9-be70-a0be13736dd8"),
                    Name = "Cliente1",
                    Secret = "123",
                    ConnectionString = "Host=localhost;Port=5433;Database=Cliente1DB;User ID=usercliente1;Password=pwdcliente1;Pooling=true;",
                    InitialUrl = "",
                    IsActive = true,
                },
                new Tenant
                {
                    Id = Guid.Parse("64210b12-a8d4-44ae-b35e-b13b762c4179"),
                    Name = "Cliente2",
                    Secret = "123",
                    ConnectionString = "Host=localhost;Port=5434;Database=Cliente2DB;User ID=usercliente2;Password=pwdcliente2;Pooling=true;",
                    InitialUrl = "",
                    IsActive = true,
                },
                new Tenant
                {
                    Id = Guid.Parse("25ae8570-56b6-4a9d-9616-c15862613525"),
                    Name = "Cliente3",
                    Secret = "123",
                    ConnectionString = "Host=localhost;Port=5435;Database=Cliente3DB;User ID=usercliente3;Password=pwdcliente3;Pooling=true;",
                    InitialUrl = "",
                    IsActive = true,
                }
            });
        }
    }
}
