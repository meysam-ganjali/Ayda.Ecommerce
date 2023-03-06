using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.EcommerceDto;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product;
using Ayda.Ecommerce.ShareModels.Slider;

namespace Ayda.Ecommerce.Web.Models;

public class HomePageVM
{
    public List<CategoryDto> ChildList { get; set; }
    public List<CategoryDto> ParentList { get; set; }
    public List<BannerDto> BannerDto { get; set; }
    public List<ProductDto> ProductDtos { get; set; }
}