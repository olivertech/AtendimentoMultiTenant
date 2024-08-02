namespace AtendimentoMultiTenant.Infra.ManagementArea.EntityConfigurations
{
    public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            //Common columns
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasColumnName("is_active").IsRequired().HasDefaultValue(true);
            
            //Entity columns
            builder.Property(x => x.Id).HasColumnName("Id").HasValueGenerator<GuidValueGenerator>();
            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(250).IsRequired();
            builder.Property(x => x.Description).HasColumnName("description").HasMaxLength(1500).IsRequired();
            builder.ToTable("Feature");

            //Global filter
            builder.HasQueryFilter(x => x.IsActive);
        }
    }
}
