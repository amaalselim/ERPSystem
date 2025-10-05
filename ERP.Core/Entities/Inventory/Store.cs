namespace ERP.Domain.Entities.Inventory
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; } = true;
        public int BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public Branch? Branch { get; set; }
        public string? AdminstratorId { get; set; }
        [ForeignKey(nameof(AdminstratorId))]
        public Employee? Adminstrator { get; set; }

        public ICollection<Stock>? Stocks { get; set; } = new List<Stock>();
        public ICollection<StoreHistory>? StoreHistories { get; set; } = new List<StoreHistory>();
        public ICollection<SaleInvoiceItem>? SaleInvoiceItems { get; set; } = new List<SaleInvoiceItem>();
        public ICollection<PurchaseInvoiceItem>? PurchaseInvoiceItems { get; set; } = new List<PurchaseInvoiceItem>();
    }
    // End Accounting

}
