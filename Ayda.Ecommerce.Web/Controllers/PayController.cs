using Ayda.Ecommerce.App;
using Ayda.Ecommerce.ShareModels.Finances.FeaturesInvoic;
using Ayda.Ecommerce.Utilities;
using Ayda.Ecommerce.Web.ExtationConfigur;
using Ayda.Ecommerce.Web.Utility;
using Dto.Payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Configuration;
using System.Composition;
using System.Net;
using Ayda.Ecommerce.ShareModels.Finances;
using ZarinPal.Class;

namespace Ayda.Ecommerce.Web.Controllers {
    [Authorize]
    public class PayController : Controller {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CookiesManeger _cookiesManeger;
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        public PayController(IUnitOfWork unitOfWork)
        {
            _cookiesManeger = new CookiesManeger();
            _unitOfWork = unitOfWork;
            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
        }
        public async Task<IActionResult> Index(CreateFeaturesInvoiceDto featureInvoice) {

            long? UserId = ClaimUtility.GetUserId(User);
            var userCart = await _unitOfWork.CartService.GetMyCart(_cookiesManeger.GetBrowserId(HttpContext), UserId);

            CreateFeaturesInvoiceDto createRequest = new CreateFeaturesInvoiceDto {
                UserId = UserId.Value,
                Amount = userCart.Data.TotalSum,
                PostalAddress = featureInvoice.PostalAddress,
                PostalCode = featureInvoice.PostalCode,
                InvoicePhone = featureInvoice.InvoicePhone
            };
            if (userCart.Data.TotalSum > 0) {
                var requestPay = await _unitOfWork.FinanceService.AddRequestPayAsync(createRequest);
                // ارسال در گاه پرداخت

                var result = await _payment.Request(new DtoRequest() {
                    Mobile = "",
                    CallbackUrl = $"{SD.BaseURL}Pay/Verify?guid={requestPay.Data.Guid}&cartId={userCart.Data.Id}&userId={UserId}",
                    Description = $"پرداخت فاکتور {requestPay.Data.Id} مربوط به کاربر {requestPay.Data.User.FName} {requestPay.Data.User.LName}",
                    Email = requestPay.Data.Emaile,
                    Amount = requestPay.Data.Amount,
                    MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                }, ZarinPal.Class.Payment.Mode.sandbox);
                return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");
            } else {
                return RedirectToAction("Index", "Cart");
            }
        }
        public async Task<IActionResult> Verify(Guid guid, string authority, string status, long cartId, long userId) {
            var requestPay = await _unitOfWork.FinanceService.GetRequestPayAsync(guid);

            var verification = await _payment.Verification(new DtoVerification {
                Amount = requestPay.Data.Amount,
                MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                Authority = authority
            }, Payment.Mode.sandbox);

            if (verification.Status == 100) {
                CreateInvoicDto createOrder = new CreateInvoicDto {
                    UserId = userId,
                    Authority = authority,
                    RefId = verification.RefId,
                    CartId = cartId,
                    FeaturesInvoiceId = requestPay.Data.Id,
                };
                var addOrder = await _unitOfWork.FinanceService.CreateOrderAsync(createOrder);
                ViewBag.Detaile = verification.ExtraDetail;
                ViewBag.Status = verification.Status;
                return Redirect("~/");

            } else {
                return RedirectToAction(nameof(NotVerification));
            }

        }

        public async Task<IActionResult> NotVerification() {
            return null;
        }
    }
}
