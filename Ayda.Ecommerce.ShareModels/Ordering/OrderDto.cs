using Ayda.Ecommerce.ShareModels.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.ShareModels.User;

namespace Ayda.Ecommerce.ShareModels.Ordering;

public class OrderDto:BaseDto<long>
{
    public long UserId { get; set; }
    public  ApplicationUserDto User { get; set; }

    public long RequestPayId { get; set; }
    public  RequestPayDto RequestPay { get; set; }

    public OrderStateEnumDto OrderState { get; set; }
    public string Address { get; set; }
    public string PostalCode { get; set; }
    public int Amount { get; set; }

    public  List<OrderDetailDto> OrderDetails { get; set; }
}

public class CreateOrderDto
{
    public long CartId { get; set; }
    public long RequestPayId { get; set; }
    public long UserId { get; set; }
    public string Authority { get; set; }
    public long RefId { get; set; } = 0;
}