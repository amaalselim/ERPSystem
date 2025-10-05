namespace ERP.Infrastructure.Configurations.Purchasing
{
    internal class PurchaseInvoiceConfiguration : IEntityTypeConfiguration<PurchaseInvoice>
    {
        public void Configure(EntityTypeBuilder<PurchaseInvoice> builder)
        {
            builder.ToTable("PurchaseInvoices", "Purchasing");


            builder.Property(e => e.PurchaseInvoiceKey).IsRequired().HasMaxLength(256);
            builder.Property(e => e.PurchaseInvoiceDate).IsRequired().HasColumnType("datetime");
            builder.Property(e => e.SystemDate).IsRequired().HasColumnType("datetime").HasDefaultValueSql("GETDATE()");

            builder.Property(e => e.BeforeDiscount).HasColumnType("decimal(18,2)").HasDefaultValue(0);
            builder.Property(e => e.Discount).HasColumnType("decimal(18,2)").HasDefaultValue(0);
            builder.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)").HasDefaultValue(0);
            builder.Property(e => e.TotalWritten).IsRequired().HasMaxLength(512);

            builder.HasOne(e => e.Branch)
                .WithMany(c => c.purchaseInvoices)
                .HasForeignKey(e => e.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.supplier)
                .WithMany(c => c.purchaseInvoices)
                .HasForeignKey(e => e.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Employee)
                .WithMany(c => c.PurchaseInvoices)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.PaymentMethod)
                .WithMany(c => c.PurchaseInvoices)
                .HasForeignKey(e => e.PaymentMethodId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
