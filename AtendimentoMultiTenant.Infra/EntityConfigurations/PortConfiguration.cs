using Microsoft.EntityFrameworkCore.ValueGeneration;

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

            //TODO: Seed para fins de testes... No final, esse Seed deverá ser removido
            builder.HasData(new[]
            {
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
