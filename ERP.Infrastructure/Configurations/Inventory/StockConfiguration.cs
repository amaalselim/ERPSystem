namespace ERP.Infrastructure.Configurations.Inventory
{
    internal class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stocks", "Inventory");

            builder.Property(e => e.Quantity).IsRequired().HasDefaultValue(1);
            builder.HasCheckConstraint("CK_Stock_Quantity", "Quantity >= 1 AND Quantity <= " + double.MaxValue);

            builder.HasOne(e => e.product)
                .WithMany(b => b.Stocks)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.store)
                .WithMany(b => b.Stocks)
                .HasForeignKey(e => e.StoreId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
