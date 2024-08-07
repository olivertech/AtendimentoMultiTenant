namespace AtendimentoMultiTenant.Infra.ManagementArea.EntityConfigurations
{
    public class RoleMenuConfiguration : IEntityTypeConfiguration<RoleMenu>
    {
        public void Configure(EntityTypeBuilder<RoleMenu> builder)
        {
            //Common columns
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasColumnName("is_active").IsRequired().HasDefaultValue(true);
            
            //Entity columns
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => new { x.MenuId, x.RoleId });

            builder.HasOne(nu => nu.Menu)
                    .WithMany(x => x.RoleMenus)
                    .HasForeignKey(ur => ur.MenuId).HasConstraintName("menu_Id");

            builder.HasOne(x => x.Role)
                .WithMany(x => x.MenuRoles)
                .HasForeignKey(x => x.RoleId).HasConstraintName("role_Id");

            builder.ToTable("Role_Menu");

            //Global filter
            builder.HasQueryFilter(x => x.IsActive);

            builder.HasData(new[]
            {
                new RoleMenu
                {
                    Id = Guid.Parse("47ed36c2-4e15-11ef-9dcf-0242ac1c0002"),
                    RoleId = Guid.Parse("45533ff6-3ba5-11ef-9476-0242ac130002"),
                    MenuId = Guid.Parse("af647e7a-3d74-11ef-a3ab-0242ac1c0002"),
                    IsActive = true
                },
                new RoleMenu
                {
                    Id = Guid.Parse("67a1a5c0-4e15-11ef-9dcf-0242ac1c0002"),
                    RoleId = Guid.Parse("45533ff6-3ba5-11ef-9476-0242ac130002"),
                    MenuId = Guid.Parse("f35a4eae-6eee-49e4-95a0-3df60e6ca9b0"),
                    IsActive = true
                },
                new RoleMenu
                {
                    Id = Guid.Parse("73ad14e4-4e15-11ef-9dcf-0242ac1c0002"),
                    RoleId = Guid.Parse("45533ff6-3ba5-11ef-9476-0242ac130002"),
                    MenuId = Guid.Parse("c60de74c-4e13-11ef-9dcf-0242ac1c0002"),
                    IsActive = true
                },
                new RoleMenu
                {
                    Id = Guid.Parse("7add512a-4e15-11ef-9dcf-0242ac1c0002"),
                    RoleId = Guid.Parse("45533ff6-3ba5-11ef-9476-0242ac130002"),
                    MenuId = Guid.Parse("cfc81d16-4e13-11ef-9dcf-0242ac1c0002"),
                    IsActive = true
                },
                new RoleMenu
                {
                    Id = Guid.Parse("83235528-4e15-11ef-9dcf-0242ac1c0002"),
                    RoleId = Guid.Parse("45533ff6-3ba5-11ef-9476-0242ac130002"),
                    MenuId = Guid.Parse("d8e9b6fc-4e13-11ef-9dcf-0242ac1c0002"),
                    IsActive = true
                },
                new RoleMenu
                {
                    Id = Guid.Parse("8b104688-4e15-11ef-9dcf-0242ac1c0002"),
                    RoleId = Guid.Parse("45533ff6-3ba5-11ef-9476-0242ac130002"),
                    MenuId = Guid.Parse("e1b05ce6-4e13-11ef-9dcf-0242ac1c0002"),
                    IsActive = true
                },
                new RoleMenu
                {
                    Id = Guid.Parse("956dcc4a-4e15-11ef-9dcf-0242ac1c0002"),
                    RoleId = Guid.Parse("45533ff6-3ba5-11ef-9476-0242ac130002"),
                    MenuId = Guid.Parse("f3ff2576-4e13-11ef-9dcf-0242ac1c0002"),
                    IsActive = true
                },
                new RoleMenu
                {
                    Id = Guid.Parse("a7dd1c82-4e15-11ef-9dcf-0242ac1c0002"),
                    RoleId = Guid.Parse("45533ff6-3ba5-11ef-9476-0242ac130002"),
                    MenuId = Guid.Parse("fc202fe8-4e13-11ef-9dcf-0242ac1c0002"),
                    IsActive = true
                },
                new RoleMenu
                {
                    Id = Guid.Parse("aea5373e-4e15-11ef-9dcf-0242ac1c0002"),
                    RoleId = Guid.Parse("45533ff6-3ba5-11ef-9476-0242ac130002"),
                    MenuId = Guid.Parse("02b786ee-4e14-11ef-9dcf-0242ac1c0002"),
                    IsActive = true
                }
            });
        }
    }
}
