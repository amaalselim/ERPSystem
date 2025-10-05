namespace ERP.Domain.Entities.Purchasing
{
    public class PurchaseInvoiceItem
    {
        public int Id { get; set; }
        public int quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public int PurchaseInvoiceId { get; set; }
        [ForeignKey(nameof(PurchaseInvoiceId))]
        public PurchaseInvoice? PurchaseInvoice { get; set; }

        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }

        public int StoreId { get; set; }
        [ForeignKey(nameof(StoreId))]
        public Store? Store { get; set; }
    }
    // End Accounting

}
