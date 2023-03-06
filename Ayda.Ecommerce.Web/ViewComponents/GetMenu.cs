using Ayda.Ecommerce.App;
using Microsoft.AspNetCore.Mvc;

namespace Ayda.Ecommerce.Web.ViewComponents;

public class GetMenu: ViewComponent
{
    private readonly IUnitOfWork _Menu;

    public GetMenu(IUnitOfWork menu)
    {
        _Menu = menu;
    }
    public async Task<IViewComponentResult>  InvokeAsync()
    {
        var menuItem = await _Menu.MenuService.GetAllParentMenuAsync();
        return View(viewName: "GetMenu", menuItem.Data);
    }
}