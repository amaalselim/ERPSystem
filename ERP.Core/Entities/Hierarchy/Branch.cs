namespace ERP.Domain.Entities.Hierarchy
{
    public class Branch : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsMainBranch { get; set; }
        public int CurrencyId { get; set; }
        [ForeignKey(nameof(CurrencyId))]
        public virtual Currency? Currency { get; set; }
        public virtual ICollection<Department>? departments { get; set; } = new List<Department>();
        public virtual ICollection<Brand>? Brands { get; set; } = new List<Brand>();
        public virtual ICollection<Store>? Stores { get; set; } = new List<Store>();
        public virtual ICollection<Product>? Products { get; set; } = new List<Product>();
        public virtual ICollection<Supplier>? Suppliers { get; set; } = new List<Supplier>();
        public virtual ICollection<Customer>? Customers { get; set; } = new List<Customer>();
        public virtual ICollection<SaleInvoice>? saleInvoices { get; set; } = new List<SaleInvoice>();
        public virtual ICollection<PurchaseInvoice>? purchaseInvoices { get; set; } = new List<PurchaseInvoice>();
        public virtual ICollection<PaymentVoucher>? PaymentVouchers { get; set; } = new List<PaymentVoucher>();
        public virtual ICollection<ReceiptVoucher>? ReceiptVouchers { get; set; } = new List<ReceiptVoucher>();
    }
}
