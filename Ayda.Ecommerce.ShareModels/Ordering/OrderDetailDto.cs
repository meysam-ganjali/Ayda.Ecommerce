using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product;

namespace Ayda.Ecommerce.ShareModels.Ordering;

public class OrderDetailDto:BaseDto<long>
{
    public long OrderId { get; set; }
    public  OrderDto Order { get; set; }
    public int ProductId { get; set; }
    public  ProductDto Product { get; set; }
    public int Price { get; set; }
    public int Count { get; set; }
}
public class CreateOrderDetailDto {
    public long OrderId { get; set; }
    public int ProductId { get; set; }
    public int Price { get; set; }
    public int Count { get; set; }
}