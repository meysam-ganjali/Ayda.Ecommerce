using Ayda.Ecommerce.App;
using Ayda.Ecommerce.ShareModels.Role;
using Ayda.Ecommerce.Web.ExtationConfigur;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var roles =await  _unitOfWork.RoleService.GetAllAsync();
            ViewBag.Role = new SelectList(roles.Data, "Id", "Name");
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
        [HttpPost]
        public async Task<IActionResult> ChangeRole(int roleId, long userId) {
            var res = await _unitOfWork.UserService.ChangeRoleAsync(userId, roleId);
            return Json(res);
        }
    }
}
