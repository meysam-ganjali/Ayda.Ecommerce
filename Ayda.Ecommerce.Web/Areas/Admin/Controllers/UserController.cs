using Ayda.Ecommerce.App;
using Ayda.Ecommerce.Web.ExtationConfigur;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ayda.Ecommerce.Web.Areas.Admin.Controllers {
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index(string? filter, string? filterUser, int page = 1, int pageSize = 100) {
            var model = _unitOfWork.UserService.GetUserForAdmin(filterUser, filter, pageSize, page);
            return View(model.Data);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeLock(int id) {
            var result = await _unitOfWork.UserService.LockOnLockAsync(id);
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeActive(int id) {
            var result = await _unitOfWork.UserService.ActiveDeActiveAsync(id);
            return Json(result);
        }
    }
}
