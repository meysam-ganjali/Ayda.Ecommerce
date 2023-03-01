using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.ShareModels.BaseModel;

namespace Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductColor;

public class ProductColorDto:BaseDto<int>
{
    public string? ColorName { get; set; }
    public string ColorHex { get; set; }
    public int ProductId { get; set; }

    public  ProductDto Product { get; set; }
}