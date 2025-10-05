namespace ERP.Domain.Entities.Inventory
{
    public class Stock
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product? product { get; set; }

        public int StoreId { get; set; }
        [ForeignKey(nameof(StoreId))]
        public virtual Store? store { get; set; }
        public virtual ICollection<StockHistory>? StockHistories { get; set; } = new List<StockHistory>();
    }
}
