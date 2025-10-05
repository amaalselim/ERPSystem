namespace ERP.Domain.Entities.Inventory
{
    public class Brand : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string? ImgPath { get; set; }
        public int BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public virtual Branch? Branch { get; set; }
        public virtual ICollection<Category>? Categories { get; set; } = new List<Category>();
    }

}
