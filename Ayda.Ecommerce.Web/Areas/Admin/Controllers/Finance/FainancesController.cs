using Ayda.Ecommerce.App;
using Ayda.Ecommerce.ShareModels.Ordering;
using Ayda.Ecommerce.Web.ExtationConfigur;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ayda.Ecommerce.Web.Areas.Admin.Controllers.Finance {
    [Area("Admin")]
    [Authorize(Roles=SD.Role_Admin)]
    public class FainancesController : Controller
    {
        private readonly IUnitOfWork _order;

        public FainancesController(IUnitOfWork order)
        {
            _order = order;
        }
        public async Task<IActionResult> OrderList(OrderStateEnumDto state = OrderStateEnumDto.Processing, int page = 1, int pageSize = 100)
        {

            var orderForAdmin = _order.FainancesService.GetOrderForAdmin(state, pageSize, page);
            return View(orderForAdmin.Data);
        }

        public async Task<IActionResult> OrderDetail(long id)
        {
            var order = await _order.FainancesService.GetOrderDetail(id);
            return View(order.Data);
        }
    }
}
