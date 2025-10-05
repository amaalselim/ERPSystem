namespace ERP.Infrastructure.Configurations.Inventory
{
    internal class StockHistoryConfiguration : IEntityTypeConfiguration<StockHistory>
    {
        public void Configure(EntityTypeBuilder<StockHistory> builder)
        {
            builder.ToTable("StockHistories", "Inventory");
            builder.HasOne(sh => sh.Stock)
                   .WithMany(s => s.StockHistories)
                   .HasForeignKey(sh => sh.StockId)
                   .OnDelete(DeleteBehavior.Restrict);





        }
    }
}
