namespace ERP.Infrastructure.Configurations.Seeding
{
    internal class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.ToTable("Units", "Seeding");
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.HasIndex(e => e.Name).IsUnique();
            builder.Property(e => e.Name).HasMaxLength(256).IsRequired();
            builder.Property(e => e.Quantity).HasDefaultValue(1)
                .HasColumnType("decimal(18,2)");

            builder.HasCheckConstraint("CK_Unit_Quantity", "Quantity >= 1 AND Quantity <= " + double.MaxValue);



        }
    }
}
