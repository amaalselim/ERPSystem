namespace ERP.Domain.Entities.Seeding
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; } = 1;
        public virtual ICollection<Product>? Products { get; set; } = new List<Product>();
    }
}
