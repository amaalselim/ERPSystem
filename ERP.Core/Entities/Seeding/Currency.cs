namespace ERP.Domain.Entities.Seeding
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Branch>? Branches { get; set; } = new List<Branch>();
    }
}
