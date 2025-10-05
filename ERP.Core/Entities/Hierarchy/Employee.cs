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
        public virtual Department? Department { get; set; }

        public int BranchId { get; set; }
        public virtual ICollection<Store>? Stores { get; set; } = new List<Store>();
        public virtual ICollection<StoreHistory> StoreHistories { get; set; } = new List<StoreHistory>();
        public virtual ICollection<StockHistory> StockHistories { get; set; } = new List<StockHistory>();
        public virtual ICollection<SaleInvoice>? SaleInvoices { get; set; } = new List<SaleInvoice>();
        public virtual ICollection<PurchaseInvoice>? PurchaseInvoices { get; set; } = new List<PurchaseInvoice>();
        public virtual ICollection<PaymentVoucher>? PaymentVouchers { get; set; } = new List<PaymentVoucher>();
        public virtual ICollection<ReceiptVoucher>? ReceiptVouchers { get; set; } = new List<ReceiptVoucher>();
    }
}
