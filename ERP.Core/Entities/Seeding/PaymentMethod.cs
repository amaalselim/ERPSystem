namespace ERP.Domain.Entities.Seeding
{
    // End Hierarchy

    //start Seeding
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<SaleInvoice>? SaleInvoices { get; set; } = new List<SaleInvoice>();
        public ICollection<PurchaseInvoice>? PurchaseInvoices { get; set; } = new List<PurchaseInvoice>();
        public ICollection<PaymentVoucher>? PaymentVouchers { get; set; } = new List<PaymentVoucher>();
        public ICollection<ReceiptVoucher>? ReceiptVouchers { get; set; } = new List<ReceiptVoucher>();
    }
    // End Accounting

}
