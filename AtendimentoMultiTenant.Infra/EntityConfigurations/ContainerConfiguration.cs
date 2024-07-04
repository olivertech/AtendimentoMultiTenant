namespace AtendimentoMultiTenant.Infra.EntityConfigurations
{
    public class ContainerConfiguration : IEntityTypeConfiguration<Container>
    {
        public void Configure(EntityTypeBuilder<Container> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ContainerName).HasMaxLength(250).IsRequired();
            builder.Property(x => x.ContainerImage).HasMaxLength(250).IsRequired();
            builder.Property(x => x.EnvironmentDbName).HasMaxLength(250).IsRequired();
            builder.Property(x => x.EnvironmentDbUser).HasMaxLength(50).IsRequired();
            builder.Property(x => x.EnvironmentDbPwd).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ContainerPort).HasMaxLength(4).IsRequired();
            builder.Property(x => x.ContainerVolume).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ContainerNetwork).HasMaxLength(50).IsRequired();
            builder.Property(x => x.IsUp).IsRequired();
            builder.Property(x => x.ContainerCreatedAt).IsRequired(false);
            builder.HasOne(x => x.Tenant);
            builder.ToTable("Container");

            //TODO: Seed para fins de testes... No final, esse Seed deverá ser removido
            builder.HasData(new[]
            {
                new Container
                {
                    Id = Guid.NewGuid(),
                    ContainerName = "postgresql_cliente1",
                    ContainerImage = "postgres:16.2",
                    EnvironmentDbName = "Cliente1DB",
                    EnvironmentDbUser = "usercliente1",
                    EnvironmentDbPwd = "pwdcliente1",
                    ContainerPort = "5434",
                    ContainerVolume = "cliente1_volume",
                    ContainerNetwork = "cliente1_network",
                    TenantId = Guid.Parse("f6a2372a-b146-45f9-be70-a0be13736dd8"),
                    IsUp = false
                },
                new Container
                {
                    Id = Guid.NewGuid(),
                    ContainerName = "postgresql_cliente2",
                    ContainerImage = "postgres:16.2",
                    EnvironmentDbName = "Cliente2DB",
                    EnvironmentDbUser = "usercliente2",
                    EnvironmentDbPwd = "pwdcliente2",
                    ContainerPort = "5435",
                    ContainerVolume = "cliente2_volume",
                    ContainerNetwork = "cliente2_network",
                    TenantId = Guid.Parse("64210b12-a8d4-44ae-b35e-b13b762c4179"),
                    IsUp = false
                },
                new Container
                {
                    Id = Guid.NewGuid(),
                    ContainerName = "postgresql_cliente3",
                    ContainerImage = "postgres:16.2",
                    EnvironmentDbName = "Cliente3DB",
                    EnvironmentDbUser = "usercliente3",
                    EnvironmentDbPwd = "pwdcliente3",
                    ContainerPort = "5436",
                    ContainerVolume = "cliente3_volume",
                    ContainerNetwork = "cliente3_network",
                    TenantId = Guid.Parse("25ae8570-56b6-4a9d-9616-c15862613525"),
                    IsUp = false
                }
            });
        }
    }
}
