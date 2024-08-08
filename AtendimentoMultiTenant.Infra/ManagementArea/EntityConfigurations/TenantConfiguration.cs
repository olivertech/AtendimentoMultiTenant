namespace AtendimentoMultiTenant.Infra.ManagementArea.EntityConfigurations
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            //Common columns
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasColumnName("is_active").IsRequired().HasDefaultValue(true);
            
            //Entity columns
            builder.Property(x => x.Id).HasColumnName("Id").HasValueGenerator<GuidValueGenerator>();
            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(250).IsRequired();
            builder.Property(x => x.Secret).HasColumnName("secret").HasMaxLength(20).IsRequired();
            builder.Property(x => x.ConnectionString).HasColumnName("connection_string").IsRequired();
            builder.Property(x => x.InitialUrl).HasColumnName("initial_url").IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired(false);
            builder.Property(x => x.TimedAt).HasColumnName("timed_at").IsRequired(false);
            builder.Property(x => x.DeativatedAt).HasColumnName("deactivated_at").IsRequired(false);
            builder.Property(x => x.DeactivatedTimedAt).HasColumnName("deactivated_timed_at").IsRequired(false);
            builder.ToTable("Tenant");

            //Global filter
            builder.HasQueryFilter(x => x.IsActive);

            builder.HasData(new[]
            {
                //=======================================================================================================
                //SEED DO BANCO DE CONFIGURAÇÃO - ESSE SEED É FIXO E NÃO DEVE SER REMOVIDO
                //O SISTEMA CONTA COM UM STARTUP DE DADOS, QUE CONTERÁ INICIALMENTE UM CONTAINER ATIVO DE CONFIGURAÇÕES
                //QUE VAI SER RESPONSÁVEL POR MANTER E GERIR TODO O RESTO DA APLICAÇÃO, MANTENDO ENTIDADES GLOBAIS
                //QUE ARMAZENAM DADOS RELACIONADOS A GESTÃO DE TODOS OS CLIENTES, SEM MANTER AQUI OS DADOS DOS CLIENTES
                //QUE FICARÃO RESTRITOS AOS CONTAINERS DE CADA CLIENTE
                //=======================================================================================================
                new Tenant
                {
                    Id = Guid.Parse("9cf0bfd2-3d70-11ef-a3ab-0242ac1c0002"),
                    Name = "Configuration",
                    Secret = "7Ej5TQznqUSkeXKZ",
                    ConnectionString = "Host=localhost;Port=5432;Database=AtendimentoConfigDB;User ID=postgresconfiguser;Password=atendimento@config;Pooling=true;",
                    InitialUrl = "",
                    IsActive = true,
                },
                //TODO: Seed para fins de testes... No final, esse Seed deverá ser removido
                new Tenant
                {
                    Id = Guid.Parse("f6a2372a-b146-45f9-be70-a0be13736dd8"),
                    Name = "Tenant 1",
                    Secret = "123",
                    ConnectionString = "Host=localhost;Port=5433;Database=Cliente1DB;User ID=usercliente1;Password=pwdcliente1;Pooling=true;",
                    InitialUrl = "",
                    IsActive = true,
                },
                new Tenant
                {
                    Id = Guid.Parse("64210b12-a8d4-44ae-b35e-b13b762c4179"),
                    Name = "Tenant 2 ",
                    Secret = "123",
                    ConnectionString = "Host=localhost;Port=5434;Database=Cliente2DB;User ID=usercliente2;Password=pwdcliente2;Pooling=true;",
                    InitialUrl = "",
                    IsActive = true,
                },
                new Tenant
                {
                    Id = Guid.Parse("25ae8570-56b6-4a9d-9616-c15862613525"),
                    Name = "Tenant 3",
                    Secret = "123",
                    ConnectionString = "Host=localhost;Port=5435;Database=Cliente3DB;User ID=usercliente3;Password=pwdcliente3;Pooling=true;",
                    InitialUrl = "",
                    IsActive = true,
                }
            });
        }
    }
}
