namespace Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductColor;

public class CreateProductColorDto {
    public string? ColorName { get; set; }
    public string ColorHex { get; set; }
    public int ProductId { get; set; }
    public bool IsShow { get; set; } = true;

}