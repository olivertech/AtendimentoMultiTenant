namespace AtendimentoMultiTenant.Infra.ManagementArea.EntityConfigurations
{
    public class SecretConfiguration : IEntityTypeConfiguration<Secret>
    {
        public void Configure(EntityTypeBuilder<Secret> builder)
        {
            //Common columns
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasColumnName("is_active").IsRequired().HasDefaultValue(true);
            
            //Entity columns
            builder.Property(x => x.Id).HasColumnName("Id").HasValueGenerator<GuidValueGenerator>();
            builder.Property(x => x.TenantId).HasColumnName("tenant_id").IsRequired();
            builder.Property(x => x.SecretKey).HasColumnName("secret_key").IsRequired();
            builder.HasOne(x => x.Tenant);
            builder.ToTable("Secret");

            //Global filter
            builder.HasQueryFilter(x => x.IsActive);
        }
    }
}
