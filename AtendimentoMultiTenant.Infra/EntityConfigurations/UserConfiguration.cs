namespace AtendimentoMultiTenant.Infra.EntityConfigurations
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

            //TODO: Seed para fins de testes... No final, esse Seed deverá ser removido
            builder.HasData(new[]
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "admin",
                    Email = "admin1@teste.com",
                    Password = "123",
                    IsActive = true,
                    TenantId = Guid.Parse("f6a2372a-b146-45f9-be70-a0be13736dd8"),
                    UserTypeId = Guid.Parse("45533ff6-3ba5-11ef-9476-0242ac130002")
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "cliente1",
                    Email = "cliente1@teste.com",
                    Password = "123",
                    IsActive = true,
                    TenantId = Guid.Parse("64210b12-a8d4-44ae-b35e-b13b762c4179"),
                    UserTypeId = Guid.Parse("6c9b91d0-3ba5-11ef-9476-0242ac130002")
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "cliente2",
                    Email = "cliente2@teste.com",
                    Password = "123",
                    IsActive = true,
                    TenantId = Guid.Parse("25ae8570-56b6-4a9d-9616-c15862613525"),
                    UserTypeId = Guid.Parse("6c9b91d0-3ba5-11ef-9476-0242ac130002")
                }
            });
        }
    }
}
