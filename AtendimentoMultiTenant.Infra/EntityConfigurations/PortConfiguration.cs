namespace AtendimentoMultiTenant.Infra.EntityConfigurations
{
    public class PortConfiguration : IEntityTypeConfiguration<Port>
    {
        public void Configure(EntityTypeBuilder<Port> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").HasValueGenerator<GuidValueGenerator>();
            builder.Property(x => x.PortNumber).HasColumnName("port_number").HasMaxLength(4).IsRequired();
            builder.ToTable("Port");

            builder.HasData(new[]
            {
                //=======================================================================================================
                //SEED DO BANCO DE CONFIGURAÇÃO - ESSE SEED É FIXO E NÃO DEVE SER REMOVIDO
                //O SISTEMA CONTA COM UM STARTUP DE DADOS, QUE CONTERÁ INICIALMENTE UM CONTAINER ATIVO DE CONFIGURAÇÕES
                //QUE VAI SER RESPONSÁVEL POR MANTER E GERIR TODO O RESTO DA APLICAÇÃO, MANTENDO ENTIDADES GLOBAIS
                //QUE ARMAZENAM DADOS RELACIONADOS A GESTÃO DE TODOS OS CLIENTES, SEM MANTER AQUI OS DADOS DOS CLIENTES
                //QUE FICARÃO RESTRITOS AOS CONTAINERS DE CADA CLIENTE
                //=======================================================================================================
                new Port
                {
                    Id = Guid.Parse("af647e7a-3d74-11ef-a3ab-0242ac1c0002"),
                    PortNumber = "5432"
                },
                //TODO: Seed para fins de testes... No final, esse Seed deverá ser removido
                new Port
                {
                    Id = Guid.Parse("f35a4eae-6eee-49e4-95a0-3df60e6ca9b0"),
                    PortNumber = "5434"
                },
                new Port
                {
                    Id = Guid.Parse("62afeccd-c9bb-48b2-a60b-0c5fe2b38694"),
                    PortNumber = "5435"
                },
                new Port
                {
                    Id = Guid.Parse("39715917-a829-41c4-8da1-64029a0c6364"),
                    PortNumber = "5436"
                }
            });
        }
    }
}
