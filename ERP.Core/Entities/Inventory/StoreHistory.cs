namespace ERP.Domain.Entities.Inventory
{
    public class StoreHistory
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Event { get; set; } = string.Empty;
        public string CreatedByUserId { get; set; } = string.Empty;
        [ForeignKey(nameof(CreatedByUserId))]
        public Employee? Employee { get; set; }
        public int StoreId { get; set; }
        [ForeignKey(nameof(StoreId))]
        public Store? Store { get; set; }
    }
    // End Accounting

}
