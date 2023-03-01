using Microsoft.AspNetCore.Http;

namespace Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductImage;

public class CreateProductImageDto{
    public string ImagePath { get; set; }
    public string? AltTagAttribute { get; set; }
    public string? TitleTagAttribute { get; set; }
    public int ProductId { get; set; }
    public IFormFile Image { get; set; }
    public bool IsShow { get; set; } = true;
}