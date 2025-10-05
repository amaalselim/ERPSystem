using ERP.Domain.Entities.Seeding;

namespace ERP.Infrastructure.Configurations.Seeding
{
    internal class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable("PaymentMethods", "Seeding");

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.HasIndex(e => e.Name).IsUnique();
            builder.Property(e => e.Name).HasMaxLength(256).IsRequired();

            builder.HasMany(builder => builder.SaleInvoices)
                   .WithOne(invoice => invoice.PaymentMethod)
                   .HasForeignKey(invoice => invoice.PaymentMethodId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(builder => builder.PurchaseInvoices)
                     .WithOne(invoice => invoice.PaymentMethod)
                     .HasForeignKey(invoice => invoice.PaymentMethodId)
                     .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(builder => builder.PaymentVouchers)
                     .WithOne(receipt => receipt.PaymentMethod)
                     .HasForeignKey(receipt => receipt.PaymentMethodId)
                     .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(builder => builder.ReceiptVouchers)
                     .WithOne(receipt => receipt.PaymentMethod)
                     .HasForeignKey(receipt => receipt.PaymentMethodId)
                     .OnDelete(DeleteBehavior.Restrict);

            //builder.HasData(
            //    new PaymentMethod { Id = 1, Name = "Cash" },
            //    new PaymentMethod { Id = 3, Name = "Bank Transfer" },
            //    new PaymentMethod { Id = 2, Name = "Delayed" }
            //);
        }
    }
}
