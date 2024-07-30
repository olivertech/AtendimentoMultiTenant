namespace AtendimentoMultiTenant.Infra.ManagementArea.EntityConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").HasValueGenerator<GuidValueGenerator>();
            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(250).IsRequired();
            builder.ToTable("Role");

            //TODO: Seed para fins de testes... No final, esse Seed deverá ser removido
            builder.HasData(new[]
            {
                new Role
                {
                    Id = Guid.Parse("45533ff6-3ba5-11ef-9476-0242ac130002"),
                    Name = "Administrador",
                    Description = "Desciption"
                },
                new Role
                {
                    Id = Guid.Parse("6c9b91d0-3ba5-11ef-9476-0242ac130002"),
                    Name = "Operador",
                    Description = "Desciption"
                },
                new Role
                {
                    Id = Guid.Parse("740cf11e-4e2b-11ef-9dcf-0242ac1c0002"),
                    Name = "Cliente",
                    Description = "Desciption"
                }
            });
        }
    }
}
