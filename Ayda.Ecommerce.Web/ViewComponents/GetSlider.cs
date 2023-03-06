using Ayda.Ecommerce.App;
using Microsoft.AspNetCore.Mvc;

namespace Ayda.Ecommerce.Web.ViewComponents;

public class GetSlider : ViewComponent {
    private readonly IUnitOfWork _slider;

    public GetSlider(IUnitOfWork slider)
    {
        _slider = slider;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var slider = await _slider.SliderService.GetAllAsync();
        return View(viewName: "GetSlider", slider.Data);
    }
}