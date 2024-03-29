﻿using Ayda.Ecommerce.App;
using Ayda.Ecommerce.ShareModels.Menu;
using Ayda.Ecommerce.Web.ExtationConfigur;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ayda.Ecommerce.Web.Areas.Admin.Controllers.Tools {
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class MenuController : Controller {
        private readonly IUnitOfWork _menuService;

        public MenuController(IUnitOfWork menuService) {
            _menuService = menuService;
        }
        public async Task<IActionResult> Index() {
            var category = await _menuService.CategoryService.GetAllAsync();
            ViewBag.Category = new SelectList(category.Data, "Id", "Name");
            var fullMenu = await _menuService.MenuService.GetAllParentMenuAsync();
            return View(fullMenu.Data);
        }

        public async Task<IActionResult> SubMenuList(int id) {
            var category = await _menuService.CategoryService.GetAllAsync();
            ViewBag.Category = new SelectList(category.Data, "Id", "Name");
            var sub = await _menuService.MenuService.GetSubMenuByParentIdAsync(id);

            return View(sub.Data);
        }
        [HttpPost]
        public async Task<IActionResult> CreateParentMenu(CreateMenuItemDto menu) {
            var result = await _menuService.MenuService.AddParentMenuAsync(menu);
            if (result.IsSuccess) {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Menu/Index");
            }

            TempData["error"] = result.Message;
            return Redirect("/Admin/Menu/Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateParentMenu(UpdateMenuItemDto menu) {
            var result = await _menuService.MenuService.UpdateParentMenuAsync(menu);
            if (result.IsSuccess) {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Menu/Index");
            }

            TempData["error"] = result.Message;
            return Redirect("/Admin/Menu/Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveParentMenu(int id) {
            var res = await _menuService.MenuService.DeleteParentMenuAsync(id);
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeShowParentMenu(int id) {
            var res = await _menuService.MenuService.ChangeShowForParent(id);
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSubMenu(CreateSubMenuDto menu) {
            var result = await _menuService.MenuService.AddSubMenuAsync(menu);
            if (result.IsSuccess) {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Menu/Index");
            }

            TempData["error"] = result.Message;
            return Redirect("/Admin/Menu/Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSubMenu(UpdateSubMenuDto menu) {
            var result = await _menuService.MenuService.UpdateSubMenuAsync(menu);
            if (result.IsSuccess) {
                TempData["success"] = result.Message;
                return Redirect($"/Admin/Menu/SubMenuList/{menu.MenuItemId}");
            }

            TempData["error"] = result.Message;
            return Redirect($"/Admin/Menu/SubMenuList/{menu.MenuItemId}");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveSubMenu(int id) {
            var res = await _menuService.MenuService.DeleteSubMenuAsync(id);
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeShowSubMenu(int id) {
            var res = await _menuService.MenuService.ChangeShowForSub(id);
            return Json(res);
        }
    }
}
