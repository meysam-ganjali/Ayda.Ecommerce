using Ayda.Ecommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Ayda.Ecommerce.App;

namespace Ayda.Ecommerce.Web.Controllers {
    public class HomeController : Controller {
       private readonly IUnitOfWork _unitOfWork;

       public HomeController(IUnitOfWork unitOfWork)
       {
           _unitOfWork = unitOfWork;
       }
       public async Task<IActionResult> Index() {
            HomePageVM model = new HomePageVM();
            var banners = await _unitOfWork.BannerService.GetAllAsync();
            model.BannerDto = banners.Data.ToList();
            var products =  _unitOfWork.ProductService.GetProductForAdmin(null, null,100,1);
            model.ProductDtos = products.Data.EntityDto;
            return View(model);
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}