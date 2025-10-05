namespace ERP.Infrastructure.Configurations.Finance
{
    internal class PaymentVoucherConfiguration : IEntityTypeConfiguration<PaymentVoucher>
    {
        public void Configure(EntityTypeBuilder<PaymentVoucher> builder)
        {
            builder.ToTable("PaymentVouchers", "Finance");

            builder.Property(e => e.AmountPaid).IsRequired().HasColumnType("decimal(18,2)");


            builder.HasOne(e => e.Employee)
                .WithMany(a => a.PaymentVouchers)
                .HasForeignKey(e => e.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.PaymentMethod)
                .WithMany(pm => pm.PaymentVouchers)
                .HasForeignKey(e => e.PaymentMethodId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Supplier)
                 .WithMany(s => s.PaymentVouchers)
                .HasForeignKey(e => e.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasCheckConstraint("CK_PaymentVoucher_AmountPaid", "AmountPaid >= 0 AND AmountPaid <= " + double.MaxValue);

        }
    }
}
