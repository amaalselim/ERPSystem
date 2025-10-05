namespace ERP.Domain.Entities.Accounting
{
    public class SupplierAccount
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Item { get; set; } = string.Empty;
        public decimal Creditor { get; set; }
        public decimal Debtor { get; set; }

        public DateTime Date { get; set; }
        public decimal Total { get; set; }

        public int SupplierId { get; set; }
        [ForeignKey(nameof(SupplierId))]
        public Supplier? Supplier { get; set; }

    }
    // End Accounting

}
