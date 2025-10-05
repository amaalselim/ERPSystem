namespace ERP.Infrastructure.Configurations.Finance
{
    internal class ReceiptVoucherConfiguration : IEntityTypeConfiguration<ReceiptVoucher>
    {
        public void Configure(EntityTypeBuilder<ReceiptVoucher> builder)
        {
            builder.ToTable("ReceiptVouchers", "Finance");

            builder.Property(e => e.AmountPaid).IsRequired().HasColumnType("decimal(18,2)");


            builder.HasOne(e => e.Employee)
                .WithMany(a => a.ReceiptVouchers)
                .HasForeignKey(e => e.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.PaymentMethod)
                .WithMany(pm => pm.ReceiptVouchers)
                .HasForeignKey(e => e.PaymentMethodId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Customer)
                 .WithMany(s => s.ReceiptVouchers)
                .HasForeignKey(e => e.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasCheckConstraint("CK_PaymentVoucher_AmountPaid", "AmountPaid >= 0 AND AmountPaid <= " + double.MaxValue);
        }
    }
}
