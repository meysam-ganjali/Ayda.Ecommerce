using Ayda.Ecommerce.App;
using Ayda.Ecommerce.ShareModels.EcommerceDto;
using Microsoft.AspNetCore.Mvc;

namespace Ayda.Ecommerce.Web.Areas.Admin.Controllers {
    [Area("Admin")]
    public class CategoryController : Controller {
        private readonly IUnitOfWork _categoryService;

        public CategoryController(IUnitOfWork categoryService) {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index() {
            var result = await _categoryService.CategoryService.GetAllAsync();
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto)
        {
            var Images = HttpContext.Request.Form.Files;
            if (Images != null)
            {
                categoryDto.Image = Images[0];
            }
            var result = await _categoryService.CategoryService.AddAsync(categoryDto);
            if (result.IsSuccess) {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Category/Index");
            }

            TempData["error"] = result.Message;
            return Redirect("/Admin/Category/Index");
        }
    }
}
