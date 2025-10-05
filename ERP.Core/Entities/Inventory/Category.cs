namespace ERP.Domain.Entities.Inventory
{
    public class Category : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public int BrandId { get; set; }
        [ForeignKey(nameof(BrandId))]
        public virtual Brand? Brand { get; set; }
        public virtual ICollection<Product>? Products { get; set; } = new List<Product>();
    }
}
