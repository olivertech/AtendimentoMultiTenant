namespace AtendimentoMultiTenant.Infra.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id).HasName("id");
            builder.HasIndex(x => x.Email).HasDatabaseName("user_email").IsUnique();
            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email).HasColumnName("email").HasMaxLength(150).IsRequired();
            builder.Property(x => x.Password).HasColumnName("password").HasMaxLength(50).IsRequired();
            builder.Property(x => x.IsActive).HasColumnName("is_active").IsRequired().HasDefaultValue(true);
            builder.HasOne(x => x.Tenant);
            builder.ToTable("User");

            //TODO: Seed para fins de testes... No final, esse Seed deverá ser removido
            builder.HasData(new[]
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Usuario1",
                    Email = "usuario1@teste.com",
                    Password = "123",
                    IsActive = true,
                    TenantId = Guid.Parse("f6a2372a-b146-45f9-be70-a0be13736dd8")
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Usuario2",
                    Email = "usuario2@teste.com",
                    Password = "123",
                    IsActive = true,
                    TenantId = Guid.Parse("64210b12-a8d4-44ae-b35e-b13b762c4179")
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Usuario3",
                    Email = "usuario3@teste.com",
                    Password = "123",
                    IsActive = true,
                    TenantId = Guid.Parse("25ae8570-56b6-4a9d-9616-c15862613525")
                }
            });
        }
    }
}
