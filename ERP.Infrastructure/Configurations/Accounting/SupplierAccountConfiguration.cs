
using ERP.Domain.Entities.Accounting;

namespace ERP.Infrastructure.Configurations.Accounting
{
    internal class SupplierAccountConfiguration : IEntityTypeConfiguration<SupplierAccount>
    {
        public void Configure(EntityTypeBuilder<SupplierAccount> builder)
        {
            builder.ToTable("SupplierAccounts", "Accounting");
            builder.Property(e => e.ItemId).IsRequired().HasMaxLength(256);
            builder.Property(e => e.Debtor).HasColumnType("decimal(18,2)").HasDefaultValue(0);
            builder.Property(e => e.Creditor).HasColumnType("decimal(18,2)").HasDefaultValue(0);
            builder.Property(e => e.Total).HasColumnType("decimal(18,2)").HasDefaultValue(0);

            builder.HasOne(e => e.Supplier)
                .WithMany(c => c.SupplierAccounts)
                .HasForeignKey(e => e.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasCheckConstraint("CK_SupplierAccount_Debtor", "Debtor >= 0 AND Debtor <= " + double.MaxValue);
            builder.HasCheckConstraint("CK_SupplierAccount_Creditor", "Creditor >= 0 AND Creditor <= " + double.MaxValue);
            builder.HasCheckConstraint("CK_SupplierAccount_Total", "Total >= 0 AND Total <= " + double.MaxValue);
        }
    }
}
