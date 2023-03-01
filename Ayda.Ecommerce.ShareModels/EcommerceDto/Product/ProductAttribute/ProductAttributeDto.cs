
using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Attribut;

namespace Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductAttribute;

public class ProductAttributeDto:BaseDto<int>
{
    public int ProductId { get; set; }
    public  ProductDto Product { get; set; }
    public int AttributeId { get; set; }
    public  CategoryAttributeDto CategoryAttribute { get; set; }
    public string AttributeValue { get; set; }
}