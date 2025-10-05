namespace ERP.Domain.Entities.Sales
{
    public class SaleInvoiceItem
    {
        public int Id { get; set; }
        public int quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public int SaleInvoiceId { get; set; }
        [ForeignKey(nameof(SaleInvoiceId))]
        public SaleInvoice? SaleInvoice { get; set; }

        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }

        public int StoreId { get; set; }
        [ForeignKey(nameof(StoreId))]
        public Store? Store { get; set; }
    }
    // End Accounting

}
