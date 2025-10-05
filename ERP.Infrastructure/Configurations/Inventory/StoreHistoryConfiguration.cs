namespace ERP.Infrastructure.Configurations.Inventory
{
    internal class StoreHistoryConfiguration : IEntityTypeConfiguration<StoreHistory>
    {
        public void Configure(EntityTypeBuilder<StoreHistory> builder)
        {
            builder.ToTable("StoreHistories", "Inventory");
            builder.HasOne(sh => sh.Store)
                   .WithMany(s => s.StoreHistories)
                   .HasForeignKey(sh => sh.StoreId)
                   .OnDelete(DeleteBehavior.Restrict);



        }
    }
}
