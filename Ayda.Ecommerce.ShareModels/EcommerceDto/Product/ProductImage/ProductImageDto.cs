using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.ShareModels.BaseModel;

namespace Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductImage;

public class ProductImageDto:BaseDto<int>
{
    public string ImagePath { get; set; }
    public string? AltTagAttribute { get; set; }
    public string? TitleTagAttribute { get; set; }
    public int ProductId { get; set; }
    public  ProductDto Product { get; set; }
}