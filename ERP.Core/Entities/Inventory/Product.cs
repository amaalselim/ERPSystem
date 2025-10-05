namespace ERP.Domain.Entities.Inventory
{
    public class Product : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Category? Category { get; set; }

        public int UnitId { get; set; }
        [ForeignKey(nameof(UnitId))]
        public virtual Unit? Unit { get; set; }

        public int BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public virtual Branch? Branch { get; set; }
        public virtual ICollection<Stock>? Stocks { get; set; } = new List<Stock>();
        public virtual ICollection<SaleInvoiceItem>? SaleInvoiceItems { get; set; } = new List<SaleInvoiceItem>();
        public virtual ICollection<PurchaseInvoiceItem>? PurchaseInvoiceItems { get; set; } = new List<PurchaseInvoiceItem>();
    }
}
