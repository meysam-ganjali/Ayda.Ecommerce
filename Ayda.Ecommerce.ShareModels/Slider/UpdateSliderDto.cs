using Ayda.Ecommerce.ShareModels.BaseModel;
using Microsoft.AspNetCore.Http;

namespace Ayda.Ecommerce.ShareModels.Slider;

public class UpdateSliderDto : BaseDto<int> {
    public string? Title { get; set; }
    public IFormFile Image { get; set; }
    public string? ImagePath { get; set; }
    public string? Description { get; set; }
    public string? Link { get; set; }
    public int PossitionId { get; set; }
}