namespace ERP.Domain.Entities.Hierarchy
{
    public class Department : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public int BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public Branch? Branch { get; set; }
        public ICollection<Employee>? Employees { get; set; } = new List<Employee>();
    }
    // End Accounting

}
