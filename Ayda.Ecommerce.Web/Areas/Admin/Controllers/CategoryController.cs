using Ayda.Ecommerce.App;
using Ayda.Ecommerce.ShareModels.EcommerceDto;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Attribut;
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
            if (categoryDto.Image != null) {
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
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto categoryDto) {
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

        [HttpPost]
        public async Task<IActionResult> CreateAttribute(CreateCategoryAttributeDto attr, int parentId) {
            var result = await _categoryService.CategoryService.AddAtributeAsync(attr);
            if (result.IsSuccess) {
                TempData["success"] = result.Message;
                return Redirect($"/Admin/Category/Index/{parentId}");
            }

            TempData["error"] = result.Message;
            return Redirect($"/Admin/Category/Index/{parentId}");
        }
        //id => category id
        public async Task<IActionResult> AttributeList(int id, int parentId) {
            var result = await _categoryService.CategoryService.GetAllCategoryAttributeAsync(id);
            if (result.IsSuccess) {
                return View(result.Data);
            }
            return Redirect($"/Admin/Category/index/{parentId}");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAttribute(int id) {
            var result = await _categoryService.CategoryService.RemoveCategoryAttrbuteAsync(id);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategoryAttrbiute(UpdateCategoryAttributeDto attribute)
        {
            var result = await _categoryService.CategoryService.UpdateAttributeAsync(attribute);
            if (result.IsSuccess) {
                TempData["success"] = result.Message;
                return Redirect($"/Admin/Category/AttributeList/{attribute.CategoryId}");
            }

            TempData["error"] = result.Message;
            return Redirect($"/Admin/Category/AttributeList/{attribute.CategoryId}");
        }
    }
}
