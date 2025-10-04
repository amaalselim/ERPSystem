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
        public ICollection<Department>? departments { get; set; } = new List<Department>();
        public ICollection<Currency>? Currencies { get; set; } = new List<Currency>();
        public ICollection<Brand>? Brands { get; set; } = new List<Brand>();
        public ICollection<Store> Stores { get; set; } = new List<Store>();
        public ICollection<Product>? Products { get; set; } = new List<Product>();
        public int CurrencyId { get; set; }
        [ForeignKey(nameof(CurrencyId))]
        public Currency? Currency { get; set; }
    }

    public class Department : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public int BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public Branch? Branch { get; set; }
        public ICollection<Employee>? Employees { get; set; } = new List<Employee>();
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
        public ICollection<Store> Stores { get; set; } = new List<Store>();
        public ICollection<StoreHistory> StoreHistories { get; set; } = new List<StoreHistory>();
        public ICollection<StockHistory> StockHistories { get; set; } = new List<StockHistory>();
    }

    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = "EGP";
        public bool IsActive { get; set; } = true;
        public ICollection<Branch>? Branches { get; set; } = new List<Branch>();

    }
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; } = 1;
        public ICollection<Product>? Products { get; set; } = new List<Product>();
    }

    public class Brand : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string? ImgPath { get; set; }
        public int BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public Branch? Branch { get; set; }
        public ICollection<Category>? Categories { get; set; } = new List<Category>();
    }

    public class Category : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public int BrandId { get; set; }
        [ForeignKey(nameof(BrandId))]
        public Brand? Brand { get; set; }
        public ICollection<Product>? Products { get; set; } = new List<Product>();
    }

    public class Product : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }

        public int UnitId { get; set; }
        [ForeignKey(nameof(UnitId))]
        public Unit? Unit { get; set; }

        public int BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public Branch? Branch { get; set; }
        public ICollection<Stock>? Stocks { get; set; } = new List<Stock>();
    }

    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; } = true;
        public int BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public Branch? Branch { get; set; }
        public string? AdminstratorId { get; set; }
        [ForeignKey(nameof(AdminstratorId))]
        public Employee? Adminstrator { get; set; }

        public ICollection<Stock>? Stocks { get; set; } = new List<Stock>();
        public ICollection<StoreHistory>? StoreHistories { get; set; } = new List<StoreHistory>();
    }

    public class StoreHistory
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Event { get; set; } = string.Empty;
        public string CreatedByUserId { get; set; } = string.Empty;
        [ForeignKey(nameof(CreatedByUserId))]
        public Employee? Employee { get; set; }
        public int StoreId { get; set; }
        [ForeignKey(nameof(StoreId))]
        public Store? store { get; set; }
    }

    public class Stock
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product? product { get; set; }

        public int StoreId { get; set; }
        [ForeignKey(nameof(StoreId))]
        public Store? store { get; set; }
        public ICollection<StockHistory>? StockHistories { get; set; } = new List<StockHistory>();
    }
    public class StockHistory
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Event { get; set; } = string.Empty;
        public string CreatedByUserId { get; set; } = string.Empty;
        [ForeignKey(nameof(CreatedByUserId))]
        public Employee? Employee { get; set; }
        public int StockId { get; set; }
        [ForeignKey(nameof(StockId))]
        public Stock? Stock { get; set; }
    }
}
