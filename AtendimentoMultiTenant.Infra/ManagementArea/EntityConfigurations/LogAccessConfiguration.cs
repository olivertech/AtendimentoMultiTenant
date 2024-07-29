﻿namespace AtendimentoMultiTenant.Infra.ManagementArea.EntityConfigurations
{
    public class LogAccessConfiguration : IEntityTypeConfiguration<LogAccess>
    {
        public void Configure(EntityTypeBuilder<LogAccess> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").HasValueGenerator<GuidValueGenerator>();
            builder.Property(x => x.UserId).HasColumnName("user_id").IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired(false).HasDefaultValue(DateOnly.FromDateTime(DateTime.Now));
            builder.Property(x => x.TimedAt).HasColumnName("timed_at").IsRequired(false).HasDefaultValue(TimeOnly.Parse(DateTime.Now.ToString("HH:mm:ss")));
            builder.HasOne(x => x.User);
            builder.ToTable("Log_Access");
        }
    }
}