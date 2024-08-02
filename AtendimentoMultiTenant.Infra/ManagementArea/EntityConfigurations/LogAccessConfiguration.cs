namespace AtendimentoMultiTenant.Infra.ManagementArea.EntityConfigurations
{
    public class LogAccessConfiguration : IEntityTypeConfiguration<LogAccess>
    {
        public void Configure(EntityTypeBuilder<LogAccess> builder)
        {
            //Common columns
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasColumnName("is_active").IsRequired().HasDefaultValue(true);
            
            //Entity columns
            builder.Property(x => x.Id).HasColumnName("Id").HasValueGenerator<GuidValueGenerator>();
            builder.Property(x => x.UserId).HasColumnName("user_id").IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired(false);
            builder.Property(x => x.TimedAt).HasColumnName("timed_at").IsRequired(false);
            builder.HasOne(x => x.User);
            builder.ToTable("Log_Access");

            //Global filter
            builder.HasQueryFilter(x => !x.IsActive);
        }
    }
}
