namespace ERP.Domain.Entities.Inventory
{
    public class Brand : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string? ImgPath { get; set; }
        public int BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public Branch? Branch { get; set; }
        public ICollection<Category>? Categories { get; set; } = new List<Category>();
    }
    // End Accounting

}
