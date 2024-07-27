namespace AtendimentoMultiTenant.Infra.ManagementArea.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").HasValueGenerator<GuidValueGenerator>();
            builder.HasIndex(x => x.Email).HasDatabaseName("user_email").IsUnique();
            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(250).IsRequired();
            builder.Property(x => x.Email).HasColumnName("email").HasMaxLength(250).IsRequired();
            builder.Property(x => x.Password).HasColumnName("password").HasMaxLength(50).IsRequired();
            builder.Property(x => x.IsActive).HasColumnName("is_active").IsRequired().HasDefaultValue(true);
            builder.Property(x => x.TenantId).HasColumnName("tenant_id").IsRequired();
            builder.Property(x => x.UserTypeId).HasColumnName("user_type_id").IsRequired(false);
            builder.Property(x => x.UserTokenId).HasColumnName("user_token_id").IsRequired(false);
            builder.HasOne(x => x.Tenant);
            builder.HasOne(x => x.UserType);
            builder.HasOne(x => x.UserToken);
            builder.ToTable("User");

            builder.HasData(new[]
            {
                //=======================================================================================================
                //SEED DO BANCO DE CONFIGURAÇÃO - ESSE SEED É FIXO E NÃO DEVE SER REMOVIDO
                //O SISTEMA CONTA COM UM STARTUP DE DADOS, QUE CONTERÁ INICIALMENTE UM CONTAINER ATIVO DE CONFIGURAÇÕES
                //QUE VAI SER RESPONSÁVEL POR MANTER E GERIR TODO O RESTO DA APLICAÇÃO, MANTENDO ENTIDADES GLOBAIS
                //QUE ARMAZENAM DADOS RELACIONADOS A GESTÃO DE TODOS OS CLIENTES, SEM MANTER AQUI OS DADOS DOS CLIENTES
                //QUE FICARÃO RESTRITOS AOS CONTAINERS DE CADA CLIENTE
                //=======================================================================================================
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Marcelo de Oliveira",
                    Email = "marcelo@sys.com",
                    Password = "123",
                    IsActive = true,
                    TenantId = Guid.Parse("9cf0bfd2-3d70-11ef-a3ab-0242ac1c0002"),
                    UserTypeId = Guid.Parse("45533ff6-3ba5-11ef-9476-0242ac130002")
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "João da Silva",
                    Email = "joao@sys.com",
                    Password = "123",
                    IsActive = true,
                    TenantId = Guid.Parse("9cf0bfd2-3d70-11ef-a3ab-0242ac1c0002"),
                    UserTypeId = Guid.Parse("45533ff6-3ba5-11ef-9476-0242ac130002")
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "maria da Silva",
                    Email = "maria@sys.com",
                    Password = "123",
                    IsActive = true,
                    TenantId = Guid.Parse("9cf0bfd2-3d70-11ef-a3ab-0242ac1c0002"),
                    UserTypeId = Guid.Parse("45533ff6-3ba5-11ef-9476-0242ac130002")
                },
                //TODO: Seed para fins de testes... No final, esse Seed deverá ser removido
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Paulo da Silva",
                    Email = "paulo@tenant1.com",
                    Password = "123",
                    IsActive = true,
                    TenantId = Guid.Parse("64210b12-a8d4-44ae-b35e-b13b762c4179"),
                    UserTypeId = Guid.Parse("6c9b91d0-3ba5-11ef-9476-0242ac130002")
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Jorge da Silva",
                    Email = "jorge@tenant2.com",
                    Password = "123",
                    IsActive = true,
                    TenantId = Guid.Parse("25ae8570-56b6-4a9d-9616-c15862613525"),
                    UserTypeId = Guid.Parse("6c9b91d0-3ba5-11ef-9476-0242ac130002")
                }
            });
        }
    }
}
