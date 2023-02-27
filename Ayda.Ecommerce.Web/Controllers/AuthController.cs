using Ayda.Ecommerce.ShareModels.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Ayda.Ecommerce.App;

namespace Ayda.Ecommerce.Web.Controllers {
    public class AuthController : Controller {
        private readonly IUnitOfWork _unitOfWork;

        public AuthController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Login(string? returnUrl = null) {
            returnUrl ??= Url.Content("~/");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto request, string? returnUrl = null) {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var signupResult = await _unitOfWork.AuthService.LoginAsync(request);
                if (signupResult.IsSuccess == true) {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,signupResult.Data.Id.ToString()),
                        new Claim(ClaimTypes.Email, signupResult.Data.Email),
                        new Claim(ClaimTypes.Name, signupResult.Data.FullName),
                        new Claim(ClaimTypes.MobilePhone, signupResult.Data.CellPhone),
                        new Claim(ClaimTypes.Role, signupResult.Data.RoleName),
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties() {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.Now.AddDays(5),
                    };
                    HttpContext.SignInAsync(principal, properties);
                    return LocalRedirect(returnUrl);
                }
            }
            ModelState.AddModelError(string.Empty, "ارسال پارامتر نا معنبر");
            return View();
        }
    }
}
