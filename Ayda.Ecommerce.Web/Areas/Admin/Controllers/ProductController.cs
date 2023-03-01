using Ayda.Ecommerce.App;
using Ayda.Ecommerce.Web.ExtationConfigur;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ayda.Ecommerce.Web.Areas.Admin.Controllers {     
    [Area("Admin")] 
        [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {

        private readonly IUnitOfWork _product;

        public ProductController(IUnitOfWork product)
        {
            _product = product;
        }
        public IActionResult Index() {
            return View();
        }
    }
}
