namespace ERP.Domain.Entities.Hierarchy
{
    public class Branch : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsMainBranch { get; set; }
        public ICollection<Department>? departments { get; set; } = new List<Department>();
        public ICollection<Brand>? Brands { get; set; } = new List<Brand>();
        public ICollection<Store>? Stores { get; set; } = new List<Store>();
        public ICollection<Product>? Products { get; set; } = new List<Product>();
        public int CurrencyId { get; set; }
        [ForeignKey(nameof(CurrencyId))]
        public Currency? Currency { get; set; }
        public ICollection<Supplier>? Suppliers { get; set; } = new List<Supplier>();
        public ICollection<Customer>? Customers { get; set; } = new List<Customer>();
        public ICollection<SaleInvoice>? saleInvoices { get; set; } = new List<SaleInvoice>();
        public ICollection<PurchaseInvoice>? purchaseInvoices { get; set; } = new List<PurchaseInvoice>();
        public ICollection<PaymentVoucher>? PaymentVouchers { get; set; } = new List<PaymentVoucher>();
        public ICollection<ReceiptVoucher>? ReceiptVouchers { get; set; } = new List<ReceiptVoucher>();
    }
    // End Accounting

}
