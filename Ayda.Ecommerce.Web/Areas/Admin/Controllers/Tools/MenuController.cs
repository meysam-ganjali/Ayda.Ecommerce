using Microsoft.AspNetCore.Mvc;

namespace Ayda.Ecommerce.Web.Areas.Admin.Controllers.Tools {
    public class MenuController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
