namespace AtendimentoMultiTenant.Infra.ManagementArea.EntityConfigurations
{
    public class ContainerDbConfiguration : IEntityTypeConfiguration<ContainerDb>
    {
        public void Configure(EntityTypeBuilder<ContainerDb> builder)
        {
            //Common columns
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasColumnName("is_active").IsRequired().HasDefaultValue(true);
            
            //Entity columns
            builder.Property(x => x.Id).HasColumnName("Id").HasValueGenerator<GuidValueGenerator>();
            builder.Property(x => x.ContainerDbName).HasColumnName("container_db_name").HasMaxLength(250).IsRequired();
            builder.Property(x => x.ContainerDbImage).HasColumnName("container_db_image").HasMaxLength(250).IsRequired();
            builder.Property(x => x.EnvironmentDbName).HasColumnName("environment_db_name").HasMaxLength(250).IsRequired();
            builder.Property(x => x.EnvironmentDbUser).HasColumnName("environment_db_user").HasMaxLength(50).IsRequired();
            builder.Property(x => x.EnvironmentDbPwd).HasColumnName("environment_db_pwd").HasMaxLength(50).IsRequired();
            builder.Property(x => x.ContainerDbVolume).HasColumnName("container_db_volume").HasMaxLength(50).IsRequired();
            builder.Property(x => x.ContainerDbNetwork).HasColumnName("container_db_network").HasMaxLength(50).IsRequired();
            builder.Property(x => x.ContainerDbPort).HasColumnName("container_db_port").HasMaxLength(4).IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired(false);
            builder.Property(x => x.TimedAt).HasColumnName("timed_at").IsRequired(false);
            builder.Property(x => x.DeativatedAt).HasColumnName("deactivated_at").IsRequired(false);
            builder.Property(x => x.DeactivatedTimedAt).HasColumnName("deactivated_timed_at").IsRequired(false);
            builder.Property(x => x.IsUp).HasColumnName("is_up").IsRequired();
            builder.Property(x => x.TenantId).HasColumnName("tenant_id").IsRequired();
            builder.Property(x => x.PortId).HasColumnName("port_id").IsRequired();
            builder.HasOne(x => x.Tenant);
            builder.HasOne(x => x.Port);
            builder.ToTable("Container_Db");

            //Global filter
            builder.HasQueryFilter(x => !x.IsActive);

            builder.HasData(new[]
            {
                //=======================================================================================================
                //SEED DO BANCO DE CONFIGURAÇÃO - ESSE SEED É FIXO E NÃO DEVE SER REMOVIDO
                //O SISTEMA CONTA COM UM STARTUP DE DADOS, QUE CONTERÁ INICIALMENTE UM CONTAINER ATIVO DE CONFIGURAÇÕES
                //QUE VAI SER RESPONSÁVEL POR MANTER E GERIR TODO O RESTO DA APLICAÇÃO, MANTENDO ENTIDADES GLOBAIS
                //QUE ARMAZENAM DADOS RELACIONADOS A GESTÃO DE TODOS OS CLIENTES, SEM MANTER AQUI OS DADOS DOS CLIENTES
                //QUE FICARÃO RESTRITOS AOS CONTAINERS DE CADA CLIENTE
                //=======================================================================================================
                new ContainerDb
                {
                    Id = Guid.Parse("2fb70bc4-3d70-11ef-a3ab-0242ac1c0002"),
                    ContainerDbName = "postgresql_configs",
                    ContainerDbImage = "postgres:16.2",
                    EnvironmentDbName = "AtendimentoConfigDB",
                    EnvironmentDbUser = "postgresconfiguser",
                    EnvironmentDbPwd = "atendimento@config",
                    ContainerDbPort = "5432",
                    ContainerDbVolume = "db_config_volume",
                    ContainerDbNetwork = "db_tenant_network",
                    TenantId = Guid.Parse("9cf0bfd2-3d70-11ef-a3ab-0242ac1c0002"),
                    PortId = Guid.Parse("af647e7a-3d74-11ef-a3ab-0242ac1c0002"),
                    IsUp = true
                },
                //TODO: Seed para fins de testes... No final, esse Seed deverá ser removido
                new ContainerDb
                {
                    Id = Guid.Parse("f35a4eae-6eee-49e4-95a0-3df60e6ca9b0"),
                    ContainerDbName = "postgresql_cliente1",
                    ContainerDbImage = "postgres:16.2",
                    EnvironmentDbName = "Cliente1DB",
                    EnvironmentDbUser = "usercliente1",
                    EnvironmentDbPwd = "pwdcliente1",
                    ContainerDbPort = "5434",
                    ContainerDbVolume = "cliente1_volume",
                    ContainerDbNetwork = "cliente1_network",
                    TenantId = Guid.Parse("f6a2372a-b146-45f9-be70-a0be13736dd8"),
                    PortId = Guid.Parse("f35a4eae-6eee-49e4-95a0-3df60e6ca9b0"),
                    IsUp = false
                },
                new ContainerDb
                {
                    Id = Guid.Parse("62afeccd-c9bb-48b2-a60b-0c5fe2b38694"),
                    ContainerDbName = "postgresql_cliente2",
                    ContainerDbImage = "postgres:16.2",
                    EnvironmentDbName = "Cliente2DB",
                    EnvironmentDbUser = "usercliente2",
                    EnvironmentDbPwd = "pwdcliente2",
                    ContainerDbPort = "5435",
                    ContainerDbVolume = "cliente2_volume",
                    ContainerDbNetwork = "cliente2_network",
                    TenantId = Guid.Parse("64210b12-a8d4-44ae-b35e-b13b762c4179"),
                    PortId = Guid.Parse("62afeccd-c9bb-48b2-a60b-0c5fe2b38694"),
                    IsUp = false
                },
                new ContainerDb
                {
                    Id = Guid.Parse("39715917-a829-41c4-8da1-64029a0c6364"),
                    ContainerDbName = "postgresql_cliente3",
                    ContainerDbImage = "postgres:16.2",
                    EnvironmentDbName = "Cliente3DB",
                    EnvironmentDbUser = "usercliente3",
                    EnvironmentDbPwd = "pwdcliente3",
                    ContainerDbPort = "5436",
                    ContainerDbVolume = "cliente3_volume",
                    ContainerDbNetwork = "cliente3_network",
                    TenantId = Guid.Parse("25ae8570-56b6-4a9d-9616-c15862613525"),
                    PortId = Guid.Parse("39715917-a829-41c4-8da1-64029a0c6364"),
                    IsUp = false
                }
            });
        }
    }
}
