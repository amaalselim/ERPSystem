using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Entities
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string CreatedByUserId { get; set; } = string.Empty;
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedByUserId { get; set; }
        public bool IsActive { get; set; } = true;
    }
    public class Company : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Activity { get; set; } = string.Empty;
        public string TaxNumber { get; set; } = string.Empty;
        public string RecordNumber { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string LogoPath { get; set; } = string.Empty;
        public string Seal { get; set; } = string.Empty;

    }

    public class Branch : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsMainBranch { get; set; }
        public ICollection<Department> departments { get; set; } = new List<Department>();
        public ICollection<Currency> Currencies { get; set; } = new List<Currency>();
        public ICollection<Unit> Units { get; set; } = new List<Unit>();
        public ICollection<Brand> Brands { get; set; } = new List<Brand>();
    }

    public class Department : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public int BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public Branch? Branch { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }

    public class Employee : IdentityUser
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = null;
        public bool IsActive { get; set; } = true;
        public bool IsUser { get; set; }
        public string? ImagePath { get; set; }
        public string? Signature { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public Department? Department { get; set; }
    }

    public class Currency : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = "EGP";
        public decimal ConcurrentCurrency { get; set; }
        public int BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public Branch? Branch { get; set; }

    }
    public class Unit : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; } = 1;
        public int BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public Branch? Branch { get; set; }
    }

    public class Brand : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string? ImgPath { get; set; }
        public int BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public Branch? Branch { get; set; }
    }
}
