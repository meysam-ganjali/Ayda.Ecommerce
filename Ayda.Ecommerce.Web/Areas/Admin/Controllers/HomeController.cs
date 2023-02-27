using Ayda.Ecommerce.Web.ExtationConfigur;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ayda.Ecommerce.Web.Areas.Admin.Controllers {
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
