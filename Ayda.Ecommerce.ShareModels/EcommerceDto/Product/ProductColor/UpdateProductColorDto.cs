using Ayda.Ecommerce.ShareModels.BaseModel;

namespace Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductColor;

public class UpdateProductColorDto : BaseDto<int> {
    public string? ColorName { get; set; }
    public string ColorHex { get; set; }
    public int ProductId { get; set; }
}