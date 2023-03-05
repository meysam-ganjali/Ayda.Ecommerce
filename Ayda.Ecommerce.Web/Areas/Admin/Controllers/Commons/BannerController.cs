using Ayda.Ecommerce.App;
using Ayda.Ecommerce.ShareModels.Slider;
using Ayda.Ecommerce.Web.ExtationConfigur;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ayda.Ecommerce.Web.Areas.Admin.Controllers.Commons
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class BannerController : Controller
    {
        private readonly IUnitOfWork _banner;

        public BannerController(IUnitOfWork banner)
        {
            _banner = banner;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _banner.BannerService.GetAllAsync();
            var possition = await _banner.PossitionService.GetPossitionAsync();
            ViewBag.Possition = new SelectList(possition.Data, "Id", "PossitionNameFA");
            return View(result);

        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto Banner)
        {
            var Images = HttpContext.Request.Form.Files;
            Banner.Image = Images[0];
            var result = await _banner.BannerService.AddAsync(Banner);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Banner/Index");
            }

            TempData["error"] = result.Message;
            return Redirect("/Admin/Banner/Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto Banner)
        {
            var Images = HttpContext.Request.Form.Files;
            if (Images != null)
            {
                Banner.Image = Images[0];
            }
            else
            {
                Banner.Image = null;
            }
            var result = await _banner.BannerService.UpdateAsync(Banner);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Banner/Index");
            }

            TempData["error"] = result.Message;
            return Redirect("/Admin/Banner/Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            var result = await _banner.BannerService.RemoveAsync(id);
            return Json(result);
        }
    }
}
