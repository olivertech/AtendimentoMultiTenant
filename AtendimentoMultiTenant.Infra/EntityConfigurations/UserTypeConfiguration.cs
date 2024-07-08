using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace AtendimentoMultiTenant.Infra.EntityConfigurations
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").HasValueGenerator<GuidValueGenerator>();
            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
            builder.ToTable("UserType");

            //TODO: Seed para fins de testes... No final, esse Seed deverá ser removido
            builder.HasData(new[]
            {
                new UserType
                {
                    Id = Guid.Parse("45533ff6-3ba5-11ef-9476-0242ac130002"),
                    Name = "Administrador",
                },
                new UserType
                {
                    Id = Guid.Parse("6c9b91d0-3ba5-11ef-9476-0242ac130002"),
                    Name = "Cliente",
                }
            });
        }
    }
}
