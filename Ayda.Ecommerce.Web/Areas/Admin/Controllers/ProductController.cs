using Ayda.Ecommerce.App;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product;
using Ayda.Ecommerce.Web.ExtationConfigur;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ayda.Ecommerce.Web.Areas.Admin.Controllers {
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller {

        private readonly IUnitOfWork _product;

        public ProductController(IUnitOfWork product) {
            _product = product;
        }
        public async Task<IActionResult> Index(string? search, string? filterproduct, int page = 1, int pageSize = 100) {
            var model = _product.ProductService.GetProductForAdmin(filterproduct, search, pageSize, page);
            return View(model.Data);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var category = await _product.CategoryService.GetAllAsync();
            ViewBag.Category = new SelectList(category.Data,"Id","Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto productDto)
        {
            var Images = HttpContext.Request.Form.Files;
            productDto.Image = Images[0];
            var result = await _product.ProductService.AddAsync(productDto);
            if (result.IsSuccess) {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Product/Index");
            }

            TempData["error"] = result.Message;
            return Redirect("/Admin/Product/Index");
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailes(int id)
        {
            var result = await _product.ProductService.GetByIdAsync(id);
            if (result.IsSuccess) {
                return View(result.Data);
            }

            TempData["error"] = result.Message;
            return Redirect("/Admin/Product/Index");
            return View();
        }
    }
}
