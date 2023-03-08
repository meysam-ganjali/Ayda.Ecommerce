using Ayda.Ecommerce.App;
using Ayda.Ecommerce.Utilities;
using Ayda.Ecommerce.Web.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ayda.Ecommerce.Web.Controllers {
    public class CartController : Controller
    {
        private readonly IUnitOfWork _cart;
        private readonly CookiesManeger cookiesManeger;
        public CartController(IUnitOfWork cart)
        {
            _cart = cart;
            cookiesManeger = new CookiesManeger();
        }
        [Authorize]
        public async Task<IActionResult> Index() {
            var userId = ClaimUtility.GetUserId(User);
            var resultGetLst =await  _cart.CartService.GetMyCart(cookiesManeger.GetBrowserId(HttpContext), userId);
            return View(resultGetLst.Data);
        }
        public async Task<IActionResult> AddToCart(int ProductId) {

            var resultAdd =await  _cart.CartService.AddToCart(ProductId, cookiesManeger.GetBrowserId(HttpContext));
            return RedirectToAction("Index");
        }
    }
}
