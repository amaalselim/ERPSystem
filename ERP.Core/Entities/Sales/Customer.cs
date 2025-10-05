namespace ERP.Domain.Entities.Sales
{
    public class Customer : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public decimal? FirstBalance { get; set; } = 0;
        public int BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public Branch? Branch { get; set; }
        public ICollection<SaleInvoice>? SaleInvoices { get; set; } = new List<SaleInvoice>();
        public ICollection<CustomerAccount> CustomerAccounts { get; set; }
        public ICollection<ReceiptVoucher> ReceiptVouchers = new List<ReceiptVoucher>();
    }
    // End Accounting

}
