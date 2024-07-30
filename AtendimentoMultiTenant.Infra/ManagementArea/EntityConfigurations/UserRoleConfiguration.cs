namespace AtendimentoMultiTenant.Infra.ManagementArea.EntityConfigurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => new { x.UserId, x.RoleId });

            builder.HasOne(nu => nu.User)
                    .WithMany(x => x.UserRoles)
                    .HasForeignKey(ur => ur.UserId).HasConstraintName("user_id");

            builder.HasOne(x => x.Role)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.RoleId).HasConstraintName("role_id");

            builder.Property(x => x.IsActive).HasColumnName("is_active").IsRequired();
            builder.ToTable("User_Role");

            builder.HasData(new[]
            {
                new UserRole
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.Parse("9a150059-614b-47c3-b56f-59deededd8d6"),
                    RoleId = Guid.Parse("af647e7a-3d74-11ef-a3ab-0242ac1c0002"),
                    IsActive = true
                },
            });
        }
    }
}
