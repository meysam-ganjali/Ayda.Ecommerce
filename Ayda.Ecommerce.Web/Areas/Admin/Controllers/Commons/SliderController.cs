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
    public class SliderController : Controller
    {
        private readonly IUnitOfWork _slider;

        public SliderController(IUnitOfWork slider)
        {
            _slider = slider;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _slider.SliderService.GetAllAsync();
            var possition = await _slider.PossitionService.GetPossitionAsync();
            ViewBag.Possition = new SelectList(possition.Data, "Id", "PossitionNameFA");
            return View(result);

        }

        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderDto slider)
        {
            var Images = HttpContext.Request.Form.Files;
            slider.Image = Images[0];
            var result = await _slider.SliderService.AddAsync(slider);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Slider/Index");
            }

            TempData["error"] = result.Message;
            return Redirect("/Admin/Slider/Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSlider(UpdateSliderDto slider)
        {
            var Images = HttpContext.Request.Form.Files;
            if (Images != null)
            {
                slider.Image = Images[0];
            }
            else
            {
                slider.Image = null;
            }
            var result = await _slider.SliderService.UpdateAsync(slider);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Slider/Index");
            }

            TempData["error"] = result.Message;
            return Redirect("/Admin/Slider/Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveSlider(int id)
        {
            var result = await _slider.SliderService.RemoveAsync(id);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeShow(int id) {
            var result = await _slider.SliderService.ChangeIsShow(id);
            return Json(result);
        }
    }
}
