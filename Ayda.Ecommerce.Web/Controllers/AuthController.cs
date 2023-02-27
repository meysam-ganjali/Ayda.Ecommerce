using Ayda.Ecommerce.ShareModels.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Ayda.Ecommerce.App;
using Ayda.Ecommerce.Web.ExtationConfigur;

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

        [HttpPost]
        public async Task<IActionResult> Signup(RegisterApplicationUserDto request) {

            if (request.Password != request.ConfirmPassword) {
                ModelState.AddModelError(string.Empty, "کلمه عبور با تکرار آن برابر نیست");
                return RedirectToAction(nameof(Login));
            }
            if (!ModelState.IsValid) {
                ModelState.AddModelError(string.Empty, "ارسال پارامتر نا معنبر");
                return RedirectToAction(nameof(Login));
            }

            var signeupResult = await _unitOfWork.AuthService.RegisterAsync(request);

            if (signeupResult.IsSuccess == true) {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,signeupResult.Data.Id.ToString()),
                    new Claim(ClaimTypes.Email, signeupResult.Data.Email),
                    new Claim(ClaimTypes.Name, signeupResult.Data.FullName),
                    new Claim(ClaimTypes.Role, SD.Role_Employee),
                };


                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties() {
                    IsPersistent = true
                };
                // HttpContext.SignInAsync(principal, properties);

            }
            return Redirect("/");
        }
        public IActionResult SignOut() {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
