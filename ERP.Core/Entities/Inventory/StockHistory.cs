namespace ERP.Domain.Entities.Inventory
{
    public class StockHistory
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Event { get; set; } = string.Empty;
        public string CreatedByUserId { get; set; } = string.Empty;
        [ForeignKey(nameof(CreatedByUserId))]
        public virtual Employee? Employee { get; set; }
        public int StockId { get; set; }
        [ForeignKey(nameof(StockId))]
        public virtual Stock? Stock { get; set; }
    }
}
