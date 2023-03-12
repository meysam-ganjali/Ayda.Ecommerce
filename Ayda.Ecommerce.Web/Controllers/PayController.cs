using Ayda.Ecommerce.App;
using Ayda.Ecommerce.Utilities;
using Ayda.Ecommerce.Web.ExtationConfigur;
using Ayda.Ecommerce.Web.Utility;
using Dto.Payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Ayda.Ecommerce.ShareModels.Ordering;
using ZarinPal.Class;

namespace Ayda.Ecommerce.Web.Controllers {
    [Authorize]
    public class PayController : Controller {
        private readonly CookiesManeger _cookiesManeger;
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        private readonly IUnitOfWork _unitOfWork;

        public PayController(IUnitOfWork unitOfWork) {
            _cookiesManeger = new CookiesManeger();
            _unitOfWork = unitOfWork;
            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
        }
        public async Task<IActionResult> Index(string Address, string PostalCode) {

            long? UserId = ClaimUtility.GetUserId(User);
            var userCart = await _unitOfWork.CartService.GetMyCart(_cookiesManeger.GetBrowserId(HttpContext), UserId);
            CreateRequestPayDto createRequest = new CreateRequestPayDto {
                UserId = UserId.Value,
                Amount = userCart.Data.TotalSum,
                Address = Address,
                PostalCode = PostalCode
            };
            if (userCart.Data.TotalSum > 0) {
                var requestPay = await _unitOfWork.FainancesService.AddRequestPayAsync(createRequest);
                // ارسال در گاه پرداخت

                var result = await _payment.Request(new DtoRequest() {
                    Mobile ="",
                    CallbackUrl = $"{SD.BaseURL}Pay/Verify?guid={requestPay.Data.Guid}&cartId={userCart.Data.Id}&userId={UserId}",
                    Description = $"پرداخت فاکتور {requestPay.Data.Id} مربوط به کاربر ",
                    Email = requestPay.Data.Email,
                    Amount = requestPay.Data.Amount,
                    MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                }, ZarinPal.Class.Payment.Mode.sandbox);
                return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");
            } else {
                return RedirectToAction("Index", "Cart");
            }
        }
        public async Task<IActionResult> Verify(Guid guid, string authority, string status, long cartId, long userId) {
            var requestPay = await _unitOfWork.FainancesService.GetRequestPayAsync(guid);

            var verification = await _payment.Verification(new DtoVerification {
                Amount = requestPay.Data.Amount,
                MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                Authority = authority
            }, Payment.Mode.sandbox);

            if (verification.Status == 100) {
                CreateOrderDto createOrder = new CreateOrderDto
                {
                    UserId=userId,
                    Authority = authority,
                    RefId = verification.RefId,
                    CartId = cartId,
                    RequestPayId = requestPay.Data.Id,
                    
                };
                var addOrder = await _unitOfWork.FainancesService.CreateOrderAsync(createOrder);
               // var model = await _unitOfWork.FainancesService.GetUserOrderAsync(userId);
                ViewBag.Detaile = verification.ExtraDetail;
                ViewBag.Status = verification.Status;
                return View();

            } else {
                return RedirectToAction(nameof(NotVerification));
            }

        }

        public async Task<IActionResult> NotVerification()
        {
            return View();
        }
    }
}
