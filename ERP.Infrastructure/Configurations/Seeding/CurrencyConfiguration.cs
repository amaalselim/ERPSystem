namespace ERP.Infrastructure.Configurations.Seeding
{
    internal class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("Currencies", "Seeding");
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.HasIndex(e => e.Name).IsUnique();
            builder.HasIndex(e => e.Code).IsUnique();

            builder.Property(e => e.Name).HasMaxLength(256).IsRequired();
            builder.Property(e => e.Code).HasMaxLength(10).HasDefaultValue("EGP");
            builder.Property(e => e.IsActive).HasDefaultValue(true);

        }
    }
}
