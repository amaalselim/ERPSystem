namespace ERP.Domain.Entities.Purchasing
{
    public class Supplier : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public decimal FirstBalance { get; set; }
        public int BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public virtual Branch? Branch { get; set; }
        public virtual ICollection<PurchaseInvoice>? purchaseInvoices { get; set; } = new List<PurchaseInvoice>();
        public virtual ICollection<PaymentVoucher>? PaymentVouchers { get; set; } = new List<PaymentVoucher>();
        public virtual ICollection<SupplierAccount>? SupplierAccounts { get; set; } = new List<SupplierAccount>();
    }
}
