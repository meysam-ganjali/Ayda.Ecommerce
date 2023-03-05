using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.EcommerceDto;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product;

namespace Ayda.Ecommerce.Web.Models;

public class HomePageVM
{
    public List<CategoryDto> ChildList { get; set; }
    public List<CategoryDto> ParentList { get; set; }
    public ProductDto GetProductByUser { get; set; }
}