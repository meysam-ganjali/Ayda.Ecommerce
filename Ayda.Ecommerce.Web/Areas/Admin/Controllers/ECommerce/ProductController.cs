using Ayda.Ecommerce.App;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Attribut;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductAttribute;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductColor;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductImage;
using Ayda.Ecommerce.Web.ExtationConfigur;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ayda.Ecommerce.Web.Areas.Admin.Controllers.ECommerce
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {

        private readonly IUnitOfWork _product;

        public ProductController(IUnitOfWork product)
        {
            _product = product;
        }

        public async Task<IActionResult> Index(string? search, string? filterproduct, int page = 1, int pageSize = 100)
        {
            var model = _product.ProductService.GetProductForAdmin(filterproduct, search, pageSize, page);
            return View(model.Data);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var category = await _product.CategoryService.GetAllAsync();
            ViewBag.Category = new SelectList(category.Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto productDto)
        {
            var Images = HttpContext.Request.Form.Files;
            productDto.Image = Images[0];
            var result = await _product.ProductService.AddAsync(productDto);
            if (result.IsSuccess)
            {
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

            if (result.IsSuccess)
            {
                var categoryAttribute = await _product.ProductService.GetAttribute(result.Data.CategoryId);
                ViewBag.Attribute = new SelectList(categoryAttribute.Data, "Id", "Name");
                return View(result.Data);
            }

            TempData["error"] = result.Message;
            return Redirect("/Admin/Product/Index");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddImageToGallery(CreateProductImageDto gallery)
        {
            var Images = HttpContext.Request.Form.Files;
            if (Images == null)
            {
                TempData["error"] = "تصویری انتخاب نکرده اید";
                return Redirect($"/Admin/Product/ProductDetailes/{gallery.ProductId}");
            }
            else
            {
                gallery.Image = Images[0];
            }

            var result = await _product.ProductService.AddImagesAsync(gallery);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return Redirect($"/Admin/Product/ProductDetailes/{gallery.ProductId}");
            }

            TempData["error"] = result.Message;
            return Redirect($"/Admin/Product/ProductDetailes/{gallery.ProductId}");
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAttribute(CreateProductAttributeDto attr)
        {
            var result = await _product.ProductService.AddAttributeAsync(attr);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return Redirect($"/Admin/Product/ProductDetailes/{attr.ProductId}");
            }

            TempData["error"] = result.Message;
            return Redirect($"/Admin/Product/ProductDetailes/{attr.ProductId}");
        }

        [HttpPost]
        public async Task<IActionResult> AddProductColor(CreateProductColorDto color)
        {
            var result = await _product.ProductService.AddColorAsync(color);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return Redirect($"/Admin/Product/ProductDetailes/{color.ProductId}");
            }

            TempData["error"] = result.Message;
            return Redirect($"/Admin/Product/ProductDetailes/{color.ProductId}");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeIsShow(int id)
        {
            var result = await _product.ProductService.YesOrNoIsShowProductAsync(id);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeShowInHomePage(int id)
        {
            var result = await _product.ProductService.ShowOrHideProductInHomePageAsync(id);
            return Json(result);


        }

        [HttpPost]
        public async Task<IActionResult> YesOrNoProductDiscount(int id, string? lable, bool flag)
        {
            var result = await _product.ProductService.YesOrNoProductDiscountAsync(id, lable, flag);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeIsSotial(int id)
        {
            var result = await _product.ProductService.YesOrNoProductIsSotialAsync(id);
            return Json(result);
        }
    }
}