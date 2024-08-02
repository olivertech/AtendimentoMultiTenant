namespace AtendimentoMultiTenant.Infra.ManagementArea.EntityConfigurations
{
    public class TokenAccessConfiguration : IEntityTypeConfiguration<TokenAccess>
    {
        public void Configure(EntityTypeBuilder<TokenAccess> builder)
        {
            //Common columns
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasColumnName("is_active").IsRequired().HasDefaultValue(true);
            
            //Entity columns
            builder.Property(x => x.Id).HasColumnName("Id").HasValueGenerator<GuidValueGenerator>();
            builder.Property(x => x.Token).HasColumnName("token").IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired(false).HasDefaultValue(DateOnly.FromDateTime(DateTime.Now));
            builder.Property(x => x.TimedAt).HasColumnName("timed_at").IsRequired(false).HasDefaultValue(TimeOnly.Parse(DateTime.Now.ToString("HH:mm:ss")));
            builder.Property(x => x.ExpiringAt).HasColumnName("expiring_at").IsRequired(false);
            builder.ToTable("Token_Access");

            //Global filter
            builder.HasQueryFilter(x => !x.IsActive);
        }
    }
}
