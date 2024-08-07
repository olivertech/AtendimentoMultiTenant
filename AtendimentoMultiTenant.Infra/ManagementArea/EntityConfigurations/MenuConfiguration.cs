namespace AtendimentoMultiTenant.Infra.ManagementArea.EntityConfigurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            //Common columns
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasColumnName("is_active").IsRequired().HasDefaultValue(true);

            //Entity columns
            builder.Property(x => x.Id).HasColumnName("Id").HasValueGenerator<GuidValueGenerator>();
            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(250).IsRequired();
            builder.Property(x => x.Description).HasColumnName("description").HasMaxLength(1500).IsRequired();
            builder.Property(x => x.Icone).HasColumnName("icone").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Route).HasColumnName("route").HasMaxLength(250).IsRequired();
            builder.ToTable("Menu");

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
                new Menu
                {
                    Id = Guid.Parse("af647e7a-3d74-11ef-a3ab-0242ac1c0002"),
                    Name = "Containers",
                    Description = "Description",
                    Icone = "database",
                    Route = "/containers",
                    IsActive = true,
                },
                new Menu
                {
                    Id = Guid.Parse("f35a4eae-6eee-49e4-95a0-3df60e6ca9b0"),
                    Name = "Tenants",
                    Description = "Description",
                    Icone = "location_away",
                    Route = "/tenants",
                    IsActive = true,
                },
                new Menu
                {
                    Id = Guid.Parse("c60de74c-4e13-11ef-9dcf-0242ac1c0002"),
                    Name = "Users",
                    Description = "Description",
                    Icone = "group",
                    Route = "/users",
                    IsActive = true,
                },
                new Menu
                {
                    Id = Guid.Parse("cfc81d16-4e13-11ef-9dcf-0242ac1c0002"),
                    Name = "Ports",
                    Description = "Description",
                    Icone = "leak_add",
                    Route = "/ports",
                    IsActive = true,
                },
                new Menu
                {
                    Id = Guid.Parse("d8e9b6fc-4e13-11ef-9dcf-0242ac1c0002"),
                    Name = "Features",
                    Description = "Description",
                    Icone = "category",
                    Route = "/features",
                    IsActive = true,
                },
                new Menu
                {
                    Id = Guid.Parse("e1b05ce6-4e13-11ef-9dcf-0242ac1c0002"),
                    Name = "Roles",
                    Description = "Description",
                    Icone = "settings_accessibility",
                    Route = "/roles",
                    IsActive = true,
                },
                new Menu
                {
                    Id = Guid.Parse("f3ff2576-4e13-11ef-9dcf-0242ac1c0002"),
                    Name = "User Tokens",
                    Description = "Description",
                    Icone = "token",
                    Route = "/usertokens",
                    IsActive = true,
                },
                new Menu
                {
                    Id = Guid.Parse("fc202fe8-4e13-11ef-9dcf-0242ac1c0002"),
                    Name = "Logs",
                    Description = "Description",
                    Icone = "how_to_reg",
                    Route = "/logs",
                    IsActive = true,
                },
                new Menu
                {
                    Id = Guid.Parse("02b786ee-4e14-11ef-9dcf-0242ac1c0002"),
                    Name = "Menu",
                    Description = "Description",
                    Icone = "lists",
                    Route = "/menus",
                    IsActive = true,
                },
            });
        }
    }
}
