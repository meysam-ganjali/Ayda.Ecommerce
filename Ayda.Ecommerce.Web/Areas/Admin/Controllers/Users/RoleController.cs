using Ayda.Ecommerce.App;
using Ayda.Ecommerce.ShareModels.Role;
using Ayda.Ecommerce.Web.ExtationConfigur;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ayda.Ecommerce.Web.Areas.Admin.Controllers.Users
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class RoleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _unitOfWork.RoleService.GetAllAsync();
            return View(model.Data);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto roleDto)
        {
            var result = await _unitOfWork.RoleService.AddAsync(roleDto);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Role/Index");
            }

            TempData["error"] = result.Message;
            return Redirect("/Admin/Role/Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var result = await _unitOfWork.RoleService.RemoveAsync(id);
            return Json(result);
        }
    }
}
