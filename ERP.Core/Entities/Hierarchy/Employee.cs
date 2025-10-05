namespace ERP.Domain.Entities.Hierarchy
{
    public class Employee : IdentityUser
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = null;
        public bool IsActive { get; set; } = true;
        public bool IsUser { get; set; }
        public string? ImagePath { get; set; }
        public string? Signature { get; set; }
        public int? DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public Department? Department { get; set; }

        public int BranchId { get; set; }
        public ICollection<Store>? Stores { get; set; } = new List<Store>();
        public ICollection<StoreHistory> StoreHistories { get; set; } = new List<StoreHistory>();
        public ICollection<StockHistory> StockHistories { get; set; } = new List<StockHistory>();
        public ICollection<SaleInvoice>? SaleInvoices { get; set; } = new List<SaleInvoice>();
        public ICollection<PurchaseInvoice>? PurchaseInvoices { get; set; } = new List<PurchaseInvoice>();
        public ICollection<PaymentVoucher>? PaymentVouchers { get; set; } = new List<PaymentVoucher>();
        public ICollection<ReceiptVoucher>? ReceiptVouchers { get; set; } = new List<ReceiptVoucher>();
    }
    // End Accounting

}
