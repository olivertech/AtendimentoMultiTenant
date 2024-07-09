namespace AtendimentoMultiTenant.Infra.EntityConfigurations
{
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").HasValueGenerator<GuidValueGenerator>();
            builder.Property(x => x.Token).HasColumnName("token").IsRequired();
            builder.Property(x => x.Expiration).HasColumnName("expiration").IsRequired();
            builder.ToTable("User_Token");
        }
    }
}
