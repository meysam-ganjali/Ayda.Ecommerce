using Microsoft.AspNetCore.Mvc;

namespace Ayda.Ecommerce.Web.Controllers {
    public class CartController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
