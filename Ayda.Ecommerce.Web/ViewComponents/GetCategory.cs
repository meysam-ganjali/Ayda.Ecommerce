using Ayda.Ecommerce.App;
using Microsoft.AspNetCore.Mvc;

namespace Ayda.Ecommerce.Web.ViewComponents;

public class GetCategory : ViewComponent {
    private readonly IUnitOfWork _category;

    public GetCategory(IUnitOfWork category)
    {
        _category = category;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var menuItem = await _category.CategoryService.GetForCategory();
        return View(viewName: "GetCategory", menuItem.Data);
    }
}