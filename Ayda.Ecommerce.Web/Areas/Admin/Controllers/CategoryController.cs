using Ayda.Ecommerce.App;
using Ayda.Ecommerce.ShareModels.EcommerceDto;
using Ayda.Ecommerce.Web.ExtationConfigur;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ayda.Ecommerce.Web.Areas.Admin.Controllers {
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller {
        private readonly IUnitOfWork _categoryService;

        public CategoryController(IUnitOfWork categoryService) {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index(int? id) {
            var result = await _categoryService.CategoryService.GetAllAsync(id);
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto) {
            if (categoryDto.Image != null)
            {
                var Images = HttpContext.Request.Form.Files;
                if (Images != null) {
                    categoryDto.Image = Images[0];
                }
            }
            var result = await _categoryService.CategoryService.AddAsync(categoryDto);
            if (result.IsSuccess) {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Category/Index");
            }

            TempData["error"] = result.Message;
            return Redirect("/Admin/Category/Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCategory(int id) {
            var result = await _categoryService.CategoryService.RemoveAsync(id);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto categoryDto)
        {
            if (categoryDto.Image != null) {
                var Images = HttpContext.Request.Form.Files;
                if (Images != null) {
                    categoryDto.Image = Images[0];
                }
            }
            var result = await _categoryService.CategoryService.UpdateAsync(categoryDto);
            if (result.IsSuccess) {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Category/Index");
            }

            TempData["error"] = result.Message;
            return Redirect("/Admin/Category/Index");
        }
    }
}
