namespace AtendimentoMultiTenant.Infra.ManagementArea.EntityConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").HasValueGenerator<GuidValueGenerator>();
            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(250).IsRequired();
            builder.Property(x => x.Description).HasColumnName("description").HasMaxLength(1500).IsRequired();
            builder.ToTable("Role");

            builder.HasData(new[]
            {
                //=======================================================================================================
                //SEED DO BANCO DE CONFIGURAÇÃO - ESSE SEED É FIXO E NÃO DEVE SER REMOVIDO
                //O SISTEMA CONTA COM UM STARTUP DE DADOS, QUE CONTERÁ INICIALMENTE UM CONTAINER ATIVO DE CONFIGURAÇÕES
                //QUE VAI SER RESPONSÁVEL POR MANTER E GERIR TODO O RESTO DA APLICAÇÃO, MANTENDO ENTIDADES GLOBAIS
                //QUE ARMAZENAM DADOS RELACIONADOS A GESTÃO DE TODOS OS CLIENTES, SEM MANTER AQUI OS DADOS DOS CLIENTES
                //QUE FICARÃO RESTRITOS AOS CONTAINERS DE CADA CLIENTE
                //=======================================================================================================
                new Role
                {
                    Id = Guid.Parse("af647e7a-3d74-11ef-a3ab-0242ac1c0002"),
                    Name = "Adminstrator",
                    Description = "Description",
                },
                //TODO: Seed para fins de testes... No final, esse Seed deverá ser removido
                new Role
                {
                    Id = Guid.Parse("f35a4eae-6eee-49e4-95a0-3df60e6ca9b0"),
                    Name = "Operator",
                    Description = "Description",
                },
                new Role
                {
                    Id = Guid.Parse("62afeccd-c9bb-48b2-a60b-0c5fe2b38694"),
                    Name = "Client",
                    Description = "Description",
                }
            });
        }
    }
}
