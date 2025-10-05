namespace ERP.Domain.Entities.Finance
{
    public class PaymentVoucher
    {
        public int Id { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime Date { get; set; }
        public DateTime SystemDate { get; set; } = DateTime.UtcNow;
        public string? AttachmentPath { get; set; }

        public int BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public Branch? Branch { get; set; }

        public int PaymentMethodId { get; set; }
        [ForeignKey(nameof(PaymentMethodId))]
        public PaymentMethod? PaymentMethod { get; set; }

        public int SupplierId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public Supplier? Supplier { get; set; }

        public string CreatedByUserId { get; set; } = string.Empty;
        [ForeignKey(nameof(CreatedByUserId))]
        public Employee? Employee { get; set; }
    }
    // End Accounting

}
