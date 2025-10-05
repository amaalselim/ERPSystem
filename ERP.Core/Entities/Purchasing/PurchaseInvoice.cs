namespace ERP.Domain.Entities.Purchasing
{
    public class PurchaseInvoice
    {
        public int Id { get; set; }
        public string PurchaseInvoiceKey { get; set; } = string.Empty;
        public DateTime PurchaseInvoiceDate { get; set; } = DateTime.UtcNow;
        public DateTime SystemDate { get; set; } = DateTime.UtcNow;

        public decimal BeforeDiscount { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public required string TotalWritten { get; set; }

        public int BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public virtual Branch? Branch { get; set; }

        public int SupplierId { get; set; }
        [ForeignKey(nameof(SupplierId))]
        public virtual Supplier? supplier { get; set; }

        public string EmployeeId { get; set; } = string.Empty;
        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee? Employee { get; set; }
        public int PaymentMethodId { get; set; }
        [ForeignKey(nameof(PaymentMethodId))]
        public virtual PaymentMethod? PaymentMethod { get; set; }
        public virtual ICollection<PurchaseInvoiceItem>? PurchaseInvoiceItems { get; set; } = new List<PurchaseInvoiceItem>();
    }
}
