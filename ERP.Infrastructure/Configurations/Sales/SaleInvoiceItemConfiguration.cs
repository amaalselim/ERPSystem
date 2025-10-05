using ERP.Domain.Entities.Sales;

namespace ERP.Infrastructure.Configurations.Sales
{
    internal class SaleInvoiceItemConfiguration : IEntityTypeConfiguration<SaleInvoiceItem>
    {
        public void Configure(EntityTypeBuilder<SaleInvoiceItem> builder)
        {
            builder.ToTable("SaleInvoiceItems", "Sales");

            builder.HasIndex(e => new { e.SaleInvoiceId, e.ProductId }).IsUnique();
            builder.Property(e => e.quantity).IsRequired().HasColumnType("decimal(18,2)").HasDefaultValue(1);
            builder.Property(e => e.UnitPrice).IsRequired().HasColumnType("decimal(18,2)").HasDefaultValue(0);
            builder.Property(e => e.Total).IsRequired().HasColumnType("decimal(18,2)").HasDefaultValue(0);


            builder.HasOne(e => e.SaleInvoice)
                .WithMany(si => si.SaleInvoiceItems)
                .HasForeignKey(e => e.SaleInvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Product)
                .WithMany(p => p.SaleInvoiceItems)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Store)
                .WithMany(s => s.SaleInvoiceItems)
                .HasForeignKey(e => e.StoreId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasCheckConstraint("CK_SaleInvoiceItem_quantity", "quantity >= 1 AND quantity <= " + double.MaxValue);
            builder.HasCheckConstraint("CK_SaleInvoiceItem_UnitPrice", "UnitPrice >= 0 AND UnitPrice <= " + double.MaxValue);
            builder.HasCheckConstraint("CK_SaleInvoiceItem_Total", "Total >= 0 AND Total <= " + double.MaxValue);
        }
    }
}
