using ERP.Domain.Entities.Purchasing;

namespace ERP.Infrastructure.Configurations.Purchasing
{
    internal class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers", "Purchasing");

            builder.HasIndex(e => new { e.Name, e.BranchId }).IsUnique();
            builder.HasIndex(e => new { e.Email, e.BranchId }).IsUnique();
            builder.HasIndex(e => new { e.PhoneNumber, e.BranchId }).IsUnique();

            builder.Property(e => e.Name).IsRequired().HasMaxLength(256);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(450);
            builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(30);

            builder.Property(e => e.FirstBalance).HasColumnType("decimal(18,2)").HasDefaultValue(0);

            builder.HasOne(e => e.Branch)
                .WithMany(c => c.Suppliers)
                .HasForeignKey(e => e.BranchId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
