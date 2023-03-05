using Ayda.Ecommerce.App;
using Ayda.Ecommerce.ShareModels.Role;
using Ayda.Ecommerce.Web.ExtationConfigur;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace Ayda.Ecommerce.Web.Areas.Admin.Controllers.Users
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(string? filter, string? filterUser, int page = 1, int pageSize = 100)
        {
            var model = _unitOfWork.UserService.GetUserForAdmin(filterUser, filter, pageSize, page);
            var roles = await _unitOfWork.RoleService.GetAllAsync();
            ViewBag.Role = new SelectList(roles.Data, "Id", "Name");
            return View(model.Data);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeLock(int id)
        {
            var result = await _unitOfWork.UserService.LockOnLockAsync(id);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeActive(int id)
        {
            var result = await _unitOfWork.UserService.ActiveDeActiveAsync(id);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeRole(int roleId, long userId)
        {
            var res = await _unitOfWork.UserService.ChangeRoleAsync(userId, roleId);
            return Json(res);
        }

        [HttpGet]
        public async Task<IActionResult> Detaile(long id)
        {
            var result = await _unitOfWork.UserService.GetUserByIdAsync(id);
            if (result.IsSuccess)
            {
                return View(result.Data);
            }
            else
            {
                return Redirect("/Admin/User/Index");
            }

        }

        [HttpPost]
        public async Task<IActionResult> ChangeOrAddAvatar(long id)
        {
            var avatar = HttpContext.Request.Form.Files.FirstOrDefault();
            if (avatar == null)
            {
                TempData["error"] = "تصویر انتخاب نشده است";
                return Redirect($"/Admin/User/Detaile/{id}");
            }

            var result = await _unitOfWork.UserService.AddOrChangeAvatar(id, avatar);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return Redirect($"/Admin/User/Detaile/{id}");
            }
            else
            {
                TempData["error"] = result.Message;
                return Redirect($"/Admin/User/Detaile/{id}");
            }

        }
    }
}
