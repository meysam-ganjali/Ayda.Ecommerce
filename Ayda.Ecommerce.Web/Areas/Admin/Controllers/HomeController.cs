using Microsoft.AspNetCore.Mvc;

namespace Ayda.Ecommerce.Web.Areas.Admin.Controllers {
    [Area("Admin")]
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
