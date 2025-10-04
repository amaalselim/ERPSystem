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
    }
}
