using ERP.Domain.Entities.Sales;

namespace ERP.Infrastructure.Configurations.Sales
{
    internal class SaleInvoiceConfiguration : IEntityTypeConfiguration<SaleInvoice>
    {
        public void Configure(EntityTypeBuilder<SaleInvoice> builder)
        {
            builder.ToTable("SaleInvoices", "Sales");


            builder.Property(e => e.SaleInvoiceKey).IsRequired().HasMaxLength(256);
            builder.Property(e => e.SaleInvoiceDate).IsRequired().HasColumnType("datetime");
            builder.Property(e => e.SystemDate).IsRequired().HasColumnType("datetime").HasDefaultValueSql("GETDATE()");

            builder.Property(e => e.BeforeDiscount).HasColumnType("decimal(18,2)").HasDefaultValue(0);
            builder.Property(e => e.Discount).HasColumnType("decimal(18,2)").HasDefaultValue(0);
            builder.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)").HasDefaultValue(0);
            builder.Property(e => e.TotalWritten).IsRequired().HasMaxLength(512);

            builder.HasOne(e => e.Branch)
                .WithMany(c => c.saleInvoices)
                .HasForeignKey(e => e.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Customer)
                .WithMany(c => c.SaleInvoices)
                .HasForeignKey(e => e.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Employee)
                .WithMany(c => c.SaleInvoices)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.PaymentMethod)
                .WithMany(c => c.SaleInvoices)
                .HasForeignKey(e => e.PaymentMethodId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
