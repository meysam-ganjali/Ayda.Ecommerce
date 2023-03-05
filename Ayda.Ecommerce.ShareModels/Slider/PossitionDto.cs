using Ayda.Ecommerce.ShareModels.BaseModel;

namespace Ayda.Ecommerce.ShareModels.Slider;

public class PossitionDto:BaseDto<int>
{
    public string PossitionNameFA { get; set; }
    public string ProssitionNameEN { get; set; }
    public  List<SliderDto> Sliders { get; set; }
    public  List<BannerDto> Banners { get; set; }
}

public class CreatePossitionDto
{
    public string PossitionNameFA { get; set; }
    public string ProssitionNameEN { get; set; }
}
public class UpdatePossitionDto : BaseDto<int> {
    public string PossitionNameFA { get; set; }
    public string ProssitionNameEN { get; set; }
}
