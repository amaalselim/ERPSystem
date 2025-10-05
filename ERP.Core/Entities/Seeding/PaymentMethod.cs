namespace ERP.Domain.Entities.Seeding
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<SaleInvoice>? SaleInvoices { get; set; } = new List<SaleInvoice>();
        public virtual ICollection<PurchaseInvoice>? PurchaseInvoices { get; set; } = new List<PurchaseInvoice>();
        public virtual ICollection<PaymentVoucher>? PaymentVouchers { get; set; } = new List<PaymentVoucher>();
        public virtual ICollection<ReceiptVoucher>? ReceiptVouchers { get; set; } = new List<ReceiptVoucher>();
    }
}
