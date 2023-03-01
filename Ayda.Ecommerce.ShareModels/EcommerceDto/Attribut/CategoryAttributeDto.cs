using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductAttribute;

namespace Ayda.Ecommerce.ShareModels.EcommerceDto.Attribut;

public class CategoryAttributeDto:BaseDto<int> {
    public string Name { get; set; }
    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public  CategoryDto Category { get; set; }
    public  List<ProductAttributeDto> ProductAttributes { get; set; }
}