namespace AtendimentoMultiTenant.Infra.ManagementArea.EntityConfigurations
{
    internal class UserFeatureConfiguration : IEntityTypeConfiguration<UserFeature>
    {
        public void Configure(EntityTypeBuilder<UserFeature> builder)
        {
            //Common columns
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasColumnName("is_active").IsRequired().HasDefaultValue(true);
            
            //Entity columns
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => new { x.UserId, x.FeatureId });

            builder.HasOne(nu => nu.User)
                    .WithMany(x => x.UserFeatures)
                    .HasForeignKey(nu => nu.UserId).HasConstraintName("user_id");

            builder.HasOne(x => x.Feature)
                .WithMany(x => x.UserFeatures)
                .HasForeignKey(x => x.FeatureId).HasConstraintName("feature_id");

            builder.ToTable("User_Feature");

            //Global filter
            builder.HasQueryFilter(x => !x.IsActive);
        }
    }
}
