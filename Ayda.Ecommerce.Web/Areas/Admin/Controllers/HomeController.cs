using Ayda.Ecommerce.App;


using Ayda.Ecommerce.Web.ExtationConfigur;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ayda.Ecommerce.Web.Areas.Admin.Controllers {
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class HomeController : Controller {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
           
            return View();
        }
    }
}
