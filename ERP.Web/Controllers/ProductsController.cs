using ERP.BL.ServicesBL.InventoryBL;
using ERP.Infrastructure.Extensions;
using System.Linq.Dynamic.Core;

namespace ERP.Web.Controllers
{
    public class ProductsController(ProductsServicesBL _productBl) : Controller
    {
        public async Task<IActionResult> Index(ProductFilterVM filter)
        {
            try
            {
                var model = await _productBl.PrepareModel();
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> GetProducts(ProductFilterVM filter)
        {
            try
            {
                var model = Request.Form.GetRequestForm();
                var result = _productBl.GetAllProducts(filter);
                result = result.OrderBy($"{model.SortColumn} {model.Dir}");

                var data = result.Skip(model.PageNumber).Take(model.PageSize);

                var count = result.Count();
                return Ok(new { recordsTotal = count, recordsFiltered = count, data = data });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
