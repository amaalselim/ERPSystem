namespace ERP.Infrastructure.Configurations.Hierarchy
{
    internal class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("Branches", "Hierarchy");
            builder.HasIndex(e => e.Name).IsUnique();
            builder.Property(e => e.Name).HasMaxLength(256).IsRequired();
            builder.Property(e => e.PhoneNumber).HasMaxLength(30).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(150).IsRequired();
            builder.Property(e => e.Address).HasMaxLength(450).IsRequired();
        }
    }
}
