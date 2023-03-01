namespace Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductAttribute;

public class CreateProductAttributeDto {
    public bool IsShow { get; set; } = true;
    public int ProductId { get; set; }
    public int AttributeId { get; set; }
    public string AttributeValue { get; set; }
}