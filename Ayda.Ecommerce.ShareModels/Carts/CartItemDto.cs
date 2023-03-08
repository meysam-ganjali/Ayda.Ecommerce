using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductAttribute;

namespace Ayda.Ecommerce.ShareModels.Carts;

public class CartItemDto:BaseDto<long>
{
    public int Count { get; set; }
    public int Price { get; set; }
    public long CartId { get; set; }
    public  CartDto Cart { get; set; }
    public int ProductId { get; set; }
    public  ProductDto Product { get; set; }
}

public class CreateCartItemDto
{
    public int Count { get; set; }
    public int Price { get; set; }
    public long CartId { get; set; }
    public int ProductId { get; set; }
}
public class UpdateCartItemDto : BaseDto<long> {
    public int Count { get; set; }
    public int Price { get; set; }
    public long CartId { get; set; }
    public int ProductId { get; set; }
}