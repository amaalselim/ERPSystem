namespace ERP.Domain.Entities.Sales
{
    public class SaleInvoice
    {
        public int Id { get; set; }
        public string SaleInvoiceKey { get; set; } = string.Empty;
        public DateTime SaleInvoiceDate { get; set; } = DateTime.UtcNow;
        public DateTime SystemDate { get; set; } = DateTime.UtcNow;

        public decimal BeforeDiscount { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public required string TotalWritten { get; set; }

        public int BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public Branch? Branch { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer? Customer { get; set; }

        public string EmployeeId { get; set; } = string.Empty;
        [ForeignKey(nameof(EmployeeId))]
        public Employee? Employee { get; set; }

        public int PaymentMethodId { get; set; }
        [ForeignKey(nameof(PaymentMethodId))]
        public PaymentMethod? PaymentMethod { get; set; }
        public ICollection<SaleInvoiceItem>? SaleInvoiceItems { get; set; } = new List<SaleInvoiceItem>();
    }
    // End Accounting

}
