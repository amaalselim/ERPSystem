namespace ERP.Domain.Entities.Accounting
{
    public class CustomerAccount
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Item { get; set; } = string.Empty;
        public decimal Creditor { get; set; }
        public decimal Debtor { get; set; }

        public DateTime Date { get; set; }
        public decimal Total { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer? Customer { get; set; }

    }
    // End Accounting

}
