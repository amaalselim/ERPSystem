using Microsoft.AspNetCore.Mvc.Rendering;
namespace ERP.Infrastructure.ViewModels
{
    public class ProductFilterVM
    {
        public string? NameSearch { get; set; }
        public int? CategoryId { get; set; }
        public int? BranchId { get; set; }
        public int? UnitId { get; set; }
        public List<SelectListItem> Categories { get; set; } = new();
        public List<SelectListItem> Branches { get; set; } = new();
        public List<SelectListItem> Units { get; set; } = new();

    }
}
