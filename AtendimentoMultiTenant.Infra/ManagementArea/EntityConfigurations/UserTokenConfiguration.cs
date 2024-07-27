namespace AtendimentoMultiTenant.Infra.ManagementArea.EntityConfigurations
{
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").HasValueGenerator<GuidValueGenerator>();
            builder.Property(x => x.Token).HasColumnName("token").IsRequired();
            builder.Property(x => x.CreationDate).HasColumnName("creation_date").IsRequired();
            builder.Property(x => x.ExpirationDate).HasColumnName("expiration_date").IsRequired();
            builder.ToTable("User_Token");
        }
    }
}
