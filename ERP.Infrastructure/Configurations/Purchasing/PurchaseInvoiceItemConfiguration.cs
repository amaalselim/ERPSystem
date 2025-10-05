namespace ERP.Infrastructure.Configurations.Purchasing
{
    internal class PurchaseInvoiceItemConfiguration : IEntityTypeConfiguration<PurchaseInvoiceItem>
    {
        public void Configure(EntityTypeBuilder<PurchaseInvoiceItem> builder)
        {
            builder.ToTable("PurchaseInvoiceItems", "Purchasing");
            builder.HasIndex(e => new { e.PurchaseInvoiceId, e.ProductId }).IsUnique();
            builder.Property(e => e.quantity).IsRequired().HasColumnType("decimal(18,2)").HasDefaultValue(1);
            builder.Property(e => e.UnitPrice).IsRequired().HasColumnType("decimal(18,2)").HasDefaultValue(0);
            builder.Property(e => e.Total).IsRequired().HasColumnType("decimal(18,2)").HasDefaultValue(0);

            builder.HasOne(e => e.PurchaseInvoice)
                .WithMany(pi => pi.PurchaseInvoiceItems)
                .HasForeignKey(e => e.PurchaseInvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Product)
                .WithMany(p => p.PurchaseInvoiceItems)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Store)
                .WithMany(s => s.PurchaseInvoiceItems)
                .HasForeignKey(e => e.StoreId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasCheckConstraint("CK_PurchaseInvoiceItem_quantity", "quantity >= 1 AND quantity <= " + double.MaxValue);
            builder.HasCheckConstraint("CK_PurchaseInvoiceItem_UnitPrice", "UnitPrice >= 0 AND UnitPrice <= " + double.MaxValue);
            builder.HasCheckConstraint("CK_PurchaseInvoiceItem_Total", "Total >= 0 AND Total <= " + double.MaxValue);
        }
    }
}
