using Ayda.Ecommerce.App;
using Ayda.Ecommerce.ShareModels.Finances;
using Ayda.Ecommerce.Web.ExtationConfigur;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ayda.Ecommerce.Web.Areas.Admin.Controllers.Order {
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class OrderController : Controller {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index(OrderStateDto state=OrderStateDto.Processing, int page=1,int pageSize=100)
        {
            var orderResult = _unitOfWork.FinanceService.GetOrders(state, pageSize, page);

            return View(orderResult.Data);
        }

        public async Task<IActionResult> OrderDetail(long id)
        {
            var orderDetail = await _unitOfWork.FinanceService.GetOrder(id);
            return View(orderDetail.Data);
        }

        public IActionResult RequestPays(bool? isPay=null,int page = 1, int pageSize = 100)
        {
            var request = _unitOfWork.FinanceService.GetRequestPaysAsync(isPay, pageSize, page);
            return View(request.Data);
        }
    }
}
