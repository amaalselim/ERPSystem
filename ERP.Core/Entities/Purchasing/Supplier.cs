namespace ERP.Domain.Entities.Purchasing
{
    public class Supplier : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public decimal? FirstBalance { get; set; } = 0;
        public int BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public Branch? Branch { get; set; }
        public ICollection<PurchaseInvoice> purchaseInvoices = new List<PurchaseInvoice>();
        public ICollection<PaymentVoucher> PaymentVouchers = new List<PaymentVoucher>();
        public ICollection<SupplierAccount> SupplierAccounts = new List<SupplierAccount>();
    }
    // End Accounting

}
