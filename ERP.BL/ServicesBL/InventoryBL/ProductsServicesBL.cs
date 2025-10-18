using ERP.Domain.Entities.Hierarchy;
using ERP.Domain.Entities.Inventory;
using ERP.Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ERP.BL.ServicesBL.InventoryBL
{
    public class ProductsServicesBL(IUnitOfWork _unitOfWork)
    {
        public async Task<ProductFilterVM> PrepareModel()
        {
            var categories = await _unitOfWork.Repository<Category>().GetAllQueryable(c => true)
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToListAsync();

            var branches = await _unitOfWork.Repository<Branch>().GetAllQueryable(b => true)
                .Select(b => new SelectListItem
                {
                    Text = b.Name,
                    Value = b.Id.ToString()
                }).ToListAsync();

            var units = await _unitOfWork.Repository<Unit>().GetAllQueryable(u => true)
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }).ToListAsync();

            var model = new ProductFilterVM
            {
                Categories = categories,
                Branches = branches,
                Units = units
            };
            return model;
        }

        public IQueryable<ProductViewModel> GetAllProducts(ProductFilterVM filter)
        {
            var repo = _unitOfWork.Repository<Product>();
            var query = repo.GetAllQueryable(p => true);

            query = query.Where(
                p => (string.IsNullOrEmpty(filter.NameSearch) || p.Name.Contains(filter.NameSearch))
                && (!filter.CategoryId.HasValue || p.CategoryId == filter.CategoryId)
                && (!filter.BranchId.HasValue || p.BranchId == filter.BranchId)
                && (!filter.UnitId.HasValue || p.UnitId == filter.UnitId))
                .Include(p => p.Category)
                .Include(p => p.Unit)
                .Include(p => p.Branch);

            var result = query.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryName = p.Category != null ? p.Category.Name : string.Empty,
                UnitName = p.Unit != null ? p.Unit.Name : string.Empty,
                BranchName = p.Branch != null ? p.Branch.Name : string.Empty
            });

            return result;
        }

    }
}
