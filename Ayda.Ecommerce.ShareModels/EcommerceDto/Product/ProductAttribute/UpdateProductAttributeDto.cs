using Ayda.Ecommerce.ShareModels.BaseModel;

namespace Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductAttribute;

public class UpdateProductAttributeDto : BaseDto<int> {
    public int ProductId { get; set; }
    public int AttributeId { get; set; }
    public string AttributeValue { get; set; }
}